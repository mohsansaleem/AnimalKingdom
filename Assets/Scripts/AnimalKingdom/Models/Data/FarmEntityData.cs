using System;
using UnityEngine;

namespace PG.AnimalKingdom.Models.Data
{
    [Serializable]
    public class FarmEntityData
    {
        [Range(1, 100)]
        public float MoveSpeed;
    }
}