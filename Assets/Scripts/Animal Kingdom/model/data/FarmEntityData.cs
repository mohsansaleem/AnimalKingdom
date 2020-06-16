using System;
using UnityEngine;

namespace game.animalKingdom.model.data
{
    [Serializable]
    public class FarmEntityData
    {
        [Range(1, 100)]
        public float MoveSpeed;
    }
}