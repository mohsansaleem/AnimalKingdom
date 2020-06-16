using System;
using System.Collections.Generic;

namespace PG.AnimalKingdom.Models.Data
{
    [Serializable]
    public class UserData
    {
        public HeroRemoteData HeroState;
        public List<AnimalRemoteData> AnimalsStates;
        
        public double Coins;
    }
}