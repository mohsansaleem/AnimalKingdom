using PG.animalKingdom.view.popup.popupresult;
using PG.Core.Context;

namespace PG.animalKingdom.view.popup.popupconfig
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