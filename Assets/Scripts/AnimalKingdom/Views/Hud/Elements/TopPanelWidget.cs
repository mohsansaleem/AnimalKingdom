using TMPro;
using UnityEngine;

namespace PG.AnimalKingdom.Views.Hud
{
    public class TopPanelWidget : MonoBehaviour
    {
        public TextMeshProUGUI Value;

        public void SetData(double current)
        {
            Value.text = current.ToString();
        }
    }
}
