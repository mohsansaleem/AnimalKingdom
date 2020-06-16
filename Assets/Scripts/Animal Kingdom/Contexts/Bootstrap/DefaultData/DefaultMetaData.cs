using PG.animalKingdom.model.data;
using UnityEngine;

namespace PG.animalKingdom.view
{
    [CreateAssetMenu(menuName = "Game/MetaData")]
    public class DefaultMetaData : ScriptableObject
    {
        [SerializeField]
        public MetaData Meta;
    }
}