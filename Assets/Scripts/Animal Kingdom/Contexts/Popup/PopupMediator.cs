using PG.animalKingdom.view.popup.popupconfig;
using PG.Core.Context;
using Zenject;

namespace PG.animalKingdom.view.popup
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

