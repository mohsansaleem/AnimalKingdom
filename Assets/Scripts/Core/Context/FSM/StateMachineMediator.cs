using System;
using System.Collections.Generic;
using PG.Core.installer;
using Zenject;
using RSG;
using UniRx;
using UnityEngine;

namespace PG.Core.Context
{
    public class StateMachineMediator : IInitializable, ITickable, IDisposable
    {
        protected StateBehaviour CurrentStateBehaviour;
        protected Dictionary<int, StateBehaviour> StateBehaviours = new Dictionary<int, StateBehaviour>();


        protected CompositeDisposable Disposables;

        [Inject] protected CoreSceneInstaller SceneInstaller;
        [Inject] protected readonly SignalBus SignalBus;

        public virtual void Initialize()
		{
		    Disposables = new CompositeDisposable();
            SignalBus.Subscribe<RequestStateChangeSignal>(GoToState);
        }

        public virtual void GoToState(RequestStateChangeSignal signal)
        {
            GoToState(signal.stateType);
        }

        public virtual void GoToState(int stateType)
        {
            if (!StateBehaviours.ContainsKey(stateType))
            {
                Debug.LogWarning("State Missing in Mediator.");
            }
            else if(CurrentStateBehaviour == null || StateBehaviours[stateType] != CurrentStateBehaviour)
            {
                GoToStateInternal(stateType);
            }
        }
        
        private void GoToStateInternal(int stateType)
        {
            if (StateBehaviours.ContainsKey(stateType))
            {
                if (CurrentStateBehaviour != null)
                {
                    CurrentStateBehaviour.OnStateExit();
                }
                CurrentStateBehaviour = StateBehaviours[stateType];
                
                CurrentStateBehaviour.OnStateEnter();
            }
            else
            {
                Debug.LogError($"State Id[{stateType}] doesn't Exist in the Dictionary.");
            }
        }

        public virtual Promise<IPopupResult> ShowPopup(IPopupConfig popupConfig)
        {
            return OpenPopupSignal.ShowPopup(SignalBus, popupConfig);
        }

        public virtual void Tick()
        {
            if (CurrentStateBehaviour != null)
            {
                CurrentStateBehaviour.Tick();
            }
        }

        public virtual void Dispose()
        {
            SignalBus.Unsubscribe<RequestStateChangeSignal>(GoToState);

            if (CurrentStateBehaviour != null)
            {
                CurrentStateBehaviour.OnStateExit();
            }

            Disposables.Dispose();

            StateBehaviours.Clear();
        }
    }
}
