using System;
using Sirenix.OdinInspector;

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
        
        [MinValue(1)]
        public int PenPoints;

        [MinValue(1)] 
        public float PatrolSpeed;
        
        [MinValue(1), MaxValue(20)]
        public int OccupiedSpace;
    }
}