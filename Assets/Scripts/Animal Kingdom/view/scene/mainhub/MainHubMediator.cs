using System;
using game.animalKingdom.model.remote;
using game.animalKingdom.model.scene;
using game.core;
using UniRx;
using UnityEngine;
using Zenject;

namespace game.animalKingdom.view
{
    public partial class MainHubMediator : StateMachineMediator
    {
        [Inject] private readonly MainHubView _view;

        [Inject] private readonly BootstrapModel _bootstrapModel;
        [Inject] private readonly MainHubModel _mainHubModel;
        [Inject] private readonly RemoteDataModel _remoteDataModel;

        public MainHubMediator()
        {
            Disposables = new CompositeDisposable();
        }

        public override void Initialize()
        {
            base.Initialize();
            
            StateBehaviours.Add(typeof(MainHubStateDefault), new MainHubStateDefault(this));
            
            _bootstrapModel.LoadingProgress.Subscribe(OnBootstrapState).AddTo(Disposables);
            _mainHubModel.MainHubState.Subscribe(OnMainHubStateChanged).AddTo(Disposables);
        }

        private void OnBootstrapState(BootstrapModel.ELoadingProgress state)
        {
            switch (state)
            {
                case BootstrapModel.ELoadingProgress.MainHub:
                    _view.Show();
                    break;
                default:
                    _view.Hide();
                    break;
            }
        }
        
        private void OnMainHubStateChanged(MainHubModel.EMainHubState mainHubState)
        {
            Type targetType = null;
            switch (mainHubState)
            {
                case MainHubModel.EMainHubState.Default:
                    targetType = typeof(MainHubStateDefault);
                    break;
                default:
                    Debug.LogError("Add the Missing State.");
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

