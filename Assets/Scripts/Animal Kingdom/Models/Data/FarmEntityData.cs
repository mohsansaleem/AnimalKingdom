using System;
using UnityEngine;

namespace PG.animalKingdom.model.data
{
    [Serializable]
    public class FarmEntityData
    {
        [Range(1, 100)]
        public float MoveSpeed;
    }
}