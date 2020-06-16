using System.Collections.Generic;
using PG.Core;
using PG.Core.Context;
using UnityEngine;

namespace PG.animalKingdom.view
{
    public abstract class AnimalState : StateBehaviour
    {
        protected readonly AnimalView View;

        protected AnimalState(AnimalView view)
        {
            this.View = view;
        }
    }

    public class AnimalStateIdle : AnimalState
    {
        public AnimalStateIdle(AnimalView view) : base(view)
        {
        }
    }
    
    public class AnimalStateFollow : AnimalState
    {
        public AnimalStateFollow(AnimalView view) : base(view)
        {
        }
    }

    public class AnimalStatePatrol : AnimalState
    {
        private List<Vector3> _positions = new List<Vector3>();
        private int _positionsCount;
        private int _currTargetIndex;
        
        public AnimalStatePatrol(AnimalView view) : base(view)
        {
            _positionsCount = 5;

            for (int i = 0; i < _positionsCount; i++)
            {
                _positions.Add(Utils.RandomFarmLocation);
            }
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            View.Agent.autoBraking = false;

            MoveToNextTarget();
        }

        private void MoveToNextTarget()
        {
            View.Move(_positions[_currTargetIndex = (++_currTargetIndex % _positionsCount)]);
        }
        
        public override void Tick()
        {
            base.Tick();

            // Choose the next destination point when the agent gets
            // close to the current one.
            if(!View.Agent.pathPending && View.Agent.remainingDistance <= View.Agent.stoppingDistance)
            {
                MoveToNextTarget();
            }
        }
    }
}