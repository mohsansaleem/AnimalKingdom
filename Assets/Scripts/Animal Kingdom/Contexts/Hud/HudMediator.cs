using System;
using PG.animalKingdom.model.remote;
using PG.animalKingdom.model.scene;
using PG.Core;
using PG.Core.Context;
using UniRx;
using Zenject;

namespace PG.animalKingdom.view
{
    public partial class HudMediator : StateMachineMediator
    {
        [Inject] private readonly HudView _view;

        [Inject] private readonly BootstrapModel _bootstrapModel;
        [Inject] private readonly HudModel _hudModel;
        [Inject] private readonly RemoteDataModel _remoteDataModel;

        public HudMediator()
        {
            Disposables = new CompositeDisposable();
        }

        public override void Initialize()
        {
            base.Initialize();
            
            StateBehaviours.Add(typeof(HudStateHidden), new HudStateHidden(this));
            StateBehaviours.Add(typeof(HudStateGamePlay), new HudStateGamePlay(this));

            _remoteDataModel.Coins.Subscribe(OnIdleCashUpdate).AddTo(Disposables);
            _remoteDataModel.HeroModel.RemainingTime.Subscribe(OnTimerUpdate).AddTo(Disposables);

            _bootstrapModel.LoadingProgress.Subscribe(OnLoadingStateChange).AddTo(Disposables);
            _hudModel.HudState.Subscribe(OnHudStateChanged).AddTo(Disposables);
        }

        private void OnLoadingStateChange(BootstrapModel.ELoadingProgress state)
        {
            switch (state)
            {
                case BootstrapModel.ELoadingProgress.GamePlay:
                    _hudModel.HudState.Value = HudModel.EHudState.GamePlay;
                    break;
                default:
                    _hudModel.HudState.Value = HudModel.EHudState.Hidden;
                    break;
            }
        }

        private void OnIdleCashUpdate(double coins)
        {
            _view._coinsWidget.SetData(coins);
        }

        private void OnTimerUpdate(TimeSpan timer)
        {
            _view._timerWidget.SetData(timer.TotalSeconds);
        }

        private void OnHudStateChanged(HudModel.EHudState hudState)
        {
            Type targetType = null;
            
            switch (hudState)
            {
                case HudModel.EHudState.Hidden:
                    targetType = typeof(HudStateHidden);
                    break;
                case HudModel.EHudState.GamePlay:
                    targetType = typeof(HudStateGamePlay);
                    break;
            }

            if (targetType != null &&
                (CurrentStateBehaviour == null ||
                 targetType != CurrentStateBehaviour.GetType()))
            {
                GoToState(targetType);
            }
        }
    }
}

