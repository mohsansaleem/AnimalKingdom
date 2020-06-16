using System;
using Newtonsoft.Json;
using UnityEngine;

namespace PG.AnimalKingdom.Models.Data
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