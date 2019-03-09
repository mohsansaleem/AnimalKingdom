using System;
using Sirenix.OdinInspector;

namespace game.animalKingdom.model.data
{
    [Serializable]
    public class FarmEntityData
    {
        [MinValue(1), MaxValue(100)]
        public float MoveSpeed;
    }
}