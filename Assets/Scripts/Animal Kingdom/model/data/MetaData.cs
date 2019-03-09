using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace game.animalKingdom.model.data
{
    [Serializable]
    public class MetaData
    {
        public float GameTime;
        
        [MinValue(1), MaxValue(100)]
        public int FarmSpace;
        
        [MinValue(1), MaxValue(100)]
        public int HeroSpace;
        
        // Animals in the Game.
        public List<AnimalData> Animals;
        
        public List<HeroData> HeroLevels;
    }
}