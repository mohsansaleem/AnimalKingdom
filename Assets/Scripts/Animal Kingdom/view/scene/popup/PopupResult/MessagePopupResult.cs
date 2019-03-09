using game.core.view;

namespace game.animalKingdom.view.popup.popupresult
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