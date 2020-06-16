using PG.animalKingdom.model.data;
using UnityEngine;

namespace PG.animalKingdom.view
{
    [CreateAssetMenu(menuName = "Game/Default GameState")]
    public class DefaultGameState : ScriptableObject
    {
        [SerializeField]
        public UserData User;
    }
}