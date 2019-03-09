using TMPro;
using UnityEngine;

namespace game.animalKingdom.view.popup
{
    public class PopupDialogView : MonoBehaviour
    {
        [Header("References")]
        public TextMeshProUGUI Title;
        public TextMeshProUGUI Message;
        public RectTransform ButtonsPanel;

        public void SetData(PopupData popupData)
        {
            Title.text = popupData.PopupConfig.Title;
            Message.text = popupData.PopupConfig.Description;
        }
    }
}

