using PG.AnimalKingdom.Contexts.Popup.PopupResult;
using PG.Core.Context;

namespace PG.AnimalKingdom.Contexts.Popup.popupconfig
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