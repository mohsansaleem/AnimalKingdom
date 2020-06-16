using PG.AnimalKingdom.Models.Data;
using UnityEngine;

namespace PG.AnimalKingdom.Contexts.Bootstrap.DefaultData
{
    [CreateAssetMenu(menuName = "Game/MetaData")]
    public class DefaultMetaData : ScriptableObject
    {
        [SerializeField]
        public MetaData Meta;
    }
}