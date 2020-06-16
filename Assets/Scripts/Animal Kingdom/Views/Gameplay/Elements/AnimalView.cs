using System.Collections.Generic;
using PG.animalKingdom.model.remote;
using PG.Core;
using pg.core.assets;
using PG.Core.Context;
using RSG;
using UnityEngine;

namespace PG.animalKingdom.view
{
    public class AnimalView : Movable
    {
        public override void Reinitialize<T>(FactoryObjectParams assetParams, Promise<T> assetReadyPromise)
        {
            AnimalViewParams para = assetParams as AnimalViewParams;

            // DO some stuff.
            transform.SetParent(para.parent);
            transform.position = para.AnimalModel.CurrentPosition;

            Agent.enabled = true;

            Model = para.AnimalModel;

            AnimalState = EAnimalState.Patrol;

            assetReadyPromise.Resolve(this as T);
        }

        public override void OnDespawned()
        {
            base.OnDespawned();

            AnimalState = EAnimalState.Idle;
            Agent.enabled = false;
        }

        // =======================================================================================
        // StateMachine Stuff
        #region Animal StateMachine

        private StateBehaviour _currentStateBehaviour;
        private Dictionary<EAnimalState, StateBehaviour> _stateBehaviours = 
            new Dictionary<EAnimalState, StateBehaviour>();

        public void Awake()
        {
            _stateBehaviours.Add(EAnimalState.Idle, new AnimalStateIdle(this));
            _stateBehaviours.Add(EAnimalState.Follow, new AnimalStateFollow(this));
            _stateBehaviours.Add(EAnimalState.Patrol, new AnimalStatePatrol(this));
        }

        public EAnimalState AnimalState
        {
            set
            {
                Debug.LogError(value);
                if (_currentStateBehaviour == null ||
                    _stateBehaviours[value] != _currentStateBehaviour)
                {
                    GoToState(value);
                }
            }
        }

        private void GoToState(EAnimalState stateType)
        {
            if (_stateBehaviours.ContainsKey(stateType))
            {
                if (_currentStateBehaviour != null)
                {
                    _currentStateBehaviour.OnStateExit();
                }

                _currentStateBehaviour = _stateBehaviours[stateType];
                
                _currentStateBehaviour.OnStateEnter();
            }
        }

        public void Update()
        {
            if (_currentStateBehaviour != null)
            {
                _currentStateBehaviour.Tick();
            }
        }

        private void OnDestroy()
        {
            if (_currentStateBehaviour != null)
            {
                _currentStateBehaviour.OnStateExit();
            }

            _stateBehaviours.Clear();
        }

        #endregion
    }

    public class AnimalViewParams : FactoryObjectParams
    {
        public Transform parent;
        public AnimalRemoteDataModel AnimalModel;
    }
    
    public enum EAnimalState
    {
        Idle = 0,
        Patrol,
        Follow
    }
}