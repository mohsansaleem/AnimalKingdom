using PG.AnimalKingdom.Contexts.Popup.data;
using PG.AnimalKingdom.Contexts.Popup.popupconfig;
using PG.AnimalKingdom.Contexts.Popup.sub;
using PG.AnimalKingdom.Views.Popup;
using PG.Core.Context;
using Zenject;

namespace PG.AnimalKingdom.Contexts.Popup
{
    public class PopupMediator : Mediator
    {
        [Inject] private readonly PopupView _view;
        [Inject] private readonly PopupDialogFacade.Factory _popupDialogFactory;

        public override void Initialize()
        {
            SignalBus.Subscribe<OpenPopupSignal>(Execute);
        }
        
        public void Execute(OpenPopupSignal openPopupSignalParams)
        {
            PopupData popupData = new PopupData()
            {
                PopupConfig = (PopupConfig)openPopupSignalParams.PopupConfig,
                OnPopupComplete = openPopupSignalParams.OnPopupComplete
            };

            _popupDialogFactory.Create(popupData);
        }

        public override void Dispose()
        {
            base.Dispose();

            SignalBus.Unsubscribe<OpenPopupSignal>(Execute);
        }
    }
}

