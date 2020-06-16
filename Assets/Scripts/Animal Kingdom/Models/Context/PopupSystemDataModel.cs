using PG.animalKingdom.view.popup;
using UniRx;

namespace PG.animalKingdom.model.scene
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

