using UnityEngine;
using UnityEngine.UI;

namespace PG.animalKingdom.view
{
    public class MainHubView : MonoBehaviour
    {
        public Button PlayButton;

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

