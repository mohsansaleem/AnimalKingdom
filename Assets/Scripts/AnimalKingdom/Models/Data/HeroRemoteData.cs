using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace PG.AnimalKingdom.Models.Data
{
    [Serializable]
    public class HeroRemoteData : FarmEntityRemoteData
    {
        [Min(1)]
        public int HeroLevel;

        // Id of the Animals in the Group.
        public List<long> AnimalsInGroup;

        [JsonIgnore]
        public HeroData HeroData
        {
            get
            {
                return this.FarmEntityData as HeroData;
            }
        }
    }
}