using game.core.view;

namespace game.animalKingdom.view.popup.popupresult
{
    public class YesNoPopupResult : PopupResult
    {

        public bool Yes
        {
            get
            {
                return SelectedIndex == 0;
            }
        }

        public bool No
        {
            get
            {
                return SelectedIndex == 1;
            }
        }
    }
}