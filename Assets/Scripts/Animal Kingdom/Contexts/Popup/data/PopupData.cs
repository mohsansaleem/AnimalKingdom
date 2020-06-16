using PG.animalKingdom.view.popup.popupconfig;
using PG.Core.Context;
using RSG;

namespace PG.animalKingdom.view.popup
{
    public class PopupData
    {
        public PopupConfig PopupConfig;
        public Promise<IPopupResult> OnPopupComplete;
    }
}