using game.animalKingdom.view.popup.popupresult;
using game.core.view;

namespace game.animalKingdom.view.popup.popupconfig
{
    public class MessagePopupConfig : PopupConfig
    {
        public static IPopupConfig GetMessagePopupConfig(string title, string message)
        {
            // @todo - MS - Localization.
            return PopulatedConfigInstance(new MessagePopupConfig(), title, message, "Ok");
        }


        public override IPopupResult GetPopupResult()
        {
            return new MessagePopupResult();
        }
    }
}