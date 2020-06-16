using PG.AnimalKingdom.Contexts.Popup.PopupResult;
using PG.Core.Context;

namespace PG.AnimalKingdom.Contexts.Popup.popupconfig
{
    public class YesNoPopupConfig : PopupConfig
    {
        public static IPopupConfig GetYesNoPopupConfig(string title, string question)
        {
            // @todo - MS - Localization. 
            return PopulatedConfigInstance(new YesNoPopupConfig(), title, question, "Yes", "No");
        }

        public override IPopupResult GetPopupResult()
        {
            return new YesNoPopupResult();
        }
    }
}