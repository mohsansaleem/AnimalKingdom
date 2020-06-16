using System;
using UnityEngine;

namespace game.animalKingdom.model.data
{
    [Serializable]
    public class HeroData : FarmEntityData
    {
        [Min(1)]
        public int Level;
        [Min(1)]
        public float MaxSpeed;
        [Min(1)]
        public int SpeedJump;
        [Min(1)]
        public int SpeedJumpInterval;
    }
}