using UnityEngine;

namespace PG.animalKingdom.model.remote
{
    public class EntityRemoteDataModel
    {
        public Vector3 CurrentPosition;

        public virtual float Speed
        {
            get;
        }

        public virtual float PatrolSpeed { get; }
    }
}