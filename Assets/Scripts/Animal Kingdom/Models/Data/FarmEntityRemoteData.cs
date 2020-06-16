using System;
using UnityEngine;
using Newtonsoft.Json;

namespace PG.animalKingdom.model.data
{
    [Serializable]
    public class FarmEntityRemoteData
    {
        public Vector3 CurrentPosition;

        [JsonIgnore]
        public float Speed
        {
            get { return FarmEntityData.MoveSpeed; }
        }

        [JsonIgnore] public FarmEntityData FarmEntityData { get; set; }
    }
}