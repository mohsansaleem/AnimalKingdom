using System;
using System.Collections.Generic;

namespace game.animalKingdom.model.data
{
    [Serializable]
    public class UserData
    {
        public HeroRemoteData HeroState;
        public List<AnimalRemoteData> AnimalsStates;
        
        public double Coins;
    }
}