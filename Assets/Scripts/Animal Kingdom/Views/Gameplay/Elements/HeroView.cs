using System;
using PG.animalKingdom.model.remote;
using pg.core.assets;
using RSG;
using UnityEngine;
using UnityEngine.AI;

namespace PG.animalKingdom.view
{
    public class HeroView : Movable
    {
        public Action<AnimalView> OnAnimalEnter;
        public Action<AnimalView> OnAnimalExit;

        public Action OnPenEnter;
        
        public void Initialize(HeroRemoteDataModel model)
        {
            Model = model;

            transform.position = model.CurrentPosition;
        }

        private void Start()
        {
            Agent.enabled = true;
        }

        public override void Reinitialize<T>(FactoryObjectParams assetParams, Promise<T> assetReadyPromise)
        {
            //Initialize();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Animal"))
            {
                var  comp = other.gameObject.GetComponent<AnimalView>();

                if (comp == null)
                {
                    Debug.LogError("Null");
                }
                OnAnimalEnter?.Invoke(comp);
            }
            else if (other.gameObject.CompareTag("Pen"))
            {
                OnPenEnter?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Animal"))
            {
                OnAnimalExit?.Invoke(other.gameObject.GetComponent<AnimalView>());
            }
            else if (other.gameObject.CompareTag("Pen"))
            {
                //OnPenEnter?.Invoke();
            }
        }
    }

    public abstract class Movable : FactoryObject
    {
        public NavMeshAgent Agent;
        public EntityRemoteDataModel Model;
        
        public void Move(Vector3 destination)
        {
            Agent.speed = Model.PatrolSpeed;
            Agent.SetDestination(destination);
        }
        
        // For Custom Speed.
        public void Move(Vector3 destination, float speed)
        {
            // Multiplying to increase of whole system.
            Agent.speed = speed;
            Agent.SetDestination(destination);
        }
    }
}