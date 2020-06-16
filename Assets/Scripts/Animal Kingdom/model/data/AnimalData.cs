using System;
using UnityEngine;

namespace game.animalKingdom.model.data
{
    public enum EAnimalType
    {
        Sheep = 0,
        Goat,
        Cow,
        Hen,
        Horse,
    }
    
    [Serializable]
    public class AnimalData: FarmEntityData
    {
        public EAnimalType AnimalType;
        
        [Min(1)]
        public int PenPoints;

        [Min(1)] 
        public float PatrolSpeed;
        
        [Range(1, 20)]
        public int OccupiedSpace;
    }
}