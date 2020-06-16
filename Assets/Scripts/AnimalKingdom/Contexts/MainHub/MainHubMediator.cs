using System;
using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Models.Remote;
using PG.AnimalKingdom.Views.MainHub;
using PG.Core.Context;
using UniRx;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Contexts.MainHub
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

