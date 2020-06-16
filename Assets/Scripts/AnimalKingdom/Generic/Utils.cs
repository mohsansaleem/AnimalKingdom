using UnityEngine;
using Random = System.Random;

namespace PG.AnimalKingdom.Generic
{
    public static class Utils
    {
        public static Random RandonGenerator = new Random();

        public static Vector3 RandomFarmLocation =>
            new Vector3(RandonGenerator.Next(-25, 49),
                0,
                RandonGenerator.Next(-25, 68));
    }
}