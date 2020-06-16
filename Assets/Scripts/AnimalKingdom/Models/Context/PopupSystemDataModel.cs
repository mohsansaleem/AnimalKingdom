using PG.AnimalKingdom.Contexts.Popup.data;
using UniRx;

namespace PG.AnimalKingdom.Models.Context
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

