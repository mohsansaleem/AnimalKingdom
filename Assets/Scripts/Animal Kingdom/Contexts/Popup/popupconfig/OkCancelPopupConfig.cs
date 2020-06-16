using PG.animalKingdom.view.popup.popupresult;
using PG.Core.Context;

namespace PG.animalKingdom.view.popup.popupconfig
{
    public class OkCancelPopupConfig : PopupConfig
    {
        public static IPopupConfig GetOkCancelPopupConfig(string title, string message)
        {
            // @todo - MS - Localization.
            return PopulatedConfigInstance(new OkCancelPopupConfig(), title, message, "Ok", "Cancel");
        }

        public override IPopupResult GetPopupResult()
        {
            return new OkCancelPopupResult();
        }
    }
}