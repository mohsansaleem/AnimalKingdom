using System;
using Sirenix.OdinInspector;

namespace game.animalKingdom.model.data
{
    [Serializable]
    public class HeroData : FarmEntityData
    {
        [MinValue(1)]
        public int Level;
        [MinValue(1)]
        public float MaxSpeed;
        [MinValue(1)]
        public int SpeedJump;
        [MinValue(1)]
        public int SpeedJumpInterval;
    }
}