using System;
using System.Collections.Generic;

namespace PG.animalKingdom.model.data
{
    [Serializable]
    public class UserData
    {
        public HeroRemoteData HeroState;
        public List<AnimalRemoteData> AnimalsStates;
        
        public double Coins;
    }
}