using game.animalKingdom.view.popup.popupconfig;
using game.core.view;
using RSG;

namespace game.animalKingdom.view.popup
{
    public class PopupData
    {
        public PopupConfig PopupConfig;
        public Promise<IPopupResult> OnPopupComplete;
    }
}