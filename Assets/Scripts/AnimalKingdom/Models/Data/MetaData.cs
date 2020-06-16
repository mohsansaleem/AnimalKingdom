using System;
using System.Collections.Generic;
using UnityEngine;

namespace PG.AnimalKingdom.Models.Data
{
    [Serializable]
    public class MetaData
    {
        public float GameTime;
        
        [Range(1, 100)]
        public int FarmSpace;
        
        [Range(1, 100)]
        public int HeroSpace;
        
        // Animals in the Game.
        public List<AnimalData> Animals;
        
        public List<HeroData> HeroLevels;
    }
}