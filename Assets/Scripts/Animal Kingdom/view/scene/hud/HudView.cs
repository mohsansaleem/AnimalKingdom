using UnityEngine;

namespace game.animalKingdom.view
{
    public class HudView : MonoBehaviour
    {
        [SerializeField]
        public TopPanelWidget _coinsWidget;
        [SerializeField]
        public TopPanelWidget _timerWidget;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}

