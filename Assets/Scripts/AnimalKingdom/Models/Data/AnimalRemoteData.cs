using System;
using Newtonsoft.Json;
using PG.AnimalKingdom.Generic;

namespace PG.AnimalKingdom.Models.Data
{
    [Serializable]
    public class AnimalRemoteData : FarmEntityRemoteData
    {
        public long Id;
        public EAnimalType AnimalType;
        
        [JsonIgnore]
        public AnimalData AnimalData => this.FarmEntityData as AnimalData;

        public static AnimalRemoteData GetRandom =>
            new AnimalRemoteData()
            {
                Id = DateTime.Now.Ticks,
                AnimalType = (EAnimalType) Utils.RandonGenerator.Next(0, 5),
                CurrentPosition = Utils.RandomFarmLocation
            };
    }
}