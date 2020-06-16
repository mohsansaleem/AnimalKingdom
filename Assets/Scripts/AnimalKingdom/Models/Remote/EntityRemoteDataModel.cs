using UnityEngine;

namespace PG.AnimalKingdom.Models.Remote
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