using UnityEngine;
using TMPro;

namespace PG.animalKingdom.view
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
