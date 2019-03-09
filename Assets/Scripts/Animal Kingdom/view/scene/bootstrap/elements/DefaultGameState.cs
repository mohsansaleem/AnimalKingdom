using game.animalKingdom.model.data;
using UnityEngine;

namespace game.animalKingdom.view
{
    [CreateAssetMenu(menuName = "Game/Default GameState")]
    public class DefaultGameState : ScriptableObject
    {
        [SerializeField]
        public UserData User;
    }
}