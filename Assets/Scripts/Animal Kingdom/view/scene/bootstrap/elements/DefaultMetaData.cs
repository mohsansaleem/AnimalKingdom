using game.animalKingdom.model.data;
using UnityEngine;

namespace game.animalKingdom.view
{
    [CreateAssetMenu(menuName = "Game/MetaData")]
    public class DefaultMetaData : ScriptableObject
    {
        [SerializeField]
        public MetaData Meta;
    }
}