using PG.Core.Context;

namespace PG.animalKingdom.view.popup.popupresult
{
    public class MessagePopupResult : PopupResult
    {
        public bool Ok
        {
            get
            {
                return SelectedIndex == 0;
            }
        }
    }
}