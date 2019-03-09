using game.animalKingdom.view.popup;
using UniRx;

namespace game.animalKingdom.model.scene
{
    public class PopupSystemDataModel
    {
        public ReactiveCollection<PopupData> Popups;

        public PopupSystemDataModel()
        {
            Popups = new ReactiveCollection<PopupData>();
        }
    }
}

