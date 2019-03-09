using game.animalKingdom.view.popup.popupresult;
using game.core.view;

namespace game.animalKingdom.view.popup.popupconfig
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