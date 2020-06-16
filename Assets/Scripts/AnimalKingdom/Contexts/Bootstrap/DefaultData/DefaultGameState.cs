using PG.AnimalKingdom.Models.Data;
using UnityEngine;

namespace PG.AnimalKingdom.Contexts.Bootstrap.DefaultData
{
    [CreateAssetMenu(menuName = "Game/Default GameState")]
    public class DefaultGameState : ScriptableObject
    {
        [SerializeField]
        public UserData User;
    }
}