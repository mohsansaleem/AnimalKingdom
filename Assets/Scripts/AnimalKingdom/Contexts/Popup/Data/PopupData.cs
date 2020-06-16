using PG.AnimalKingdom.Contexts.Popup.popupconfig;
using PG.Core.Context;
using RSG;

namespace PG.AnimalKingdom.Contexts.Popup.data
{
    public class PopupData
    {
        public PopupConfig PopupConfig;
        public Promise<IPopupResult> OnPopupComplete;
    }
}