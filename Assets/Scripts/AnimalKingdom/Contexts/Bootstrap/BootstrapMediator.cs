﻿using System;
using PG.AnimalKingdom.Installer;
using PG.AnimalKingdom.Models;
using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Models.Remote;
using PG.AnimalKingdom.Views.Bootstrap;
using PG.Core.Context;
using PG.Core.installer;
using UniRx;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Contexts.Bootstrap
{
    public partial class BootstrapMediator : StateMachineMediator
    {
        [Inject] private readonly BootstrapView _view;
        
        [Inject] private readonly BootstrapModel _bootstrapModel;

        [Inject] private readonly StaticDataModel _staticDataModel;
        [Inject] private readonly RemoteDataModel _remoteDataModel;

        [Inject] private ProjectContextInstaller.Settings _gameSettings;

        public BootstrapMediator()
        {
            Disposables = new CompositeDisposable();
        }

        public override void Initialize()
        {
            base.Initialize();

            StateBehaviours.Add((int)BootstrapModel.ELoadingProgress.LoadPopup, new BootstrapStateLoadPopup(this));
            StateBehaviours.Add((int)BootstrapModel.ELoadingProgress.LoadStaticData, new BootstrapStateLoadStaticData(this));
            StateBehaviours.Add((int)BootstrapModel.ELoadingProgress.CreateMetaData, new BootstrapStateCreateMetaData(this)); // Temporary State for creating MetaData
            StateBehaviours.Add((int)BootstrapModel.ELoadingProgress.LoadUserData, new BootstrapStateLoadUserData(this));
            StateBehaviours.Add((int)BootstrapModel.ELoadingProgress.CreateUserData, new BootstrapStateCreateUserData(this));
            StateBehaviours.Add((int)BootstrapModel.ELoadingProgress.LoadHud, new BootstrapStateLoadHud(this));
            StateBehaviours.Add((int)BootstrapModel.ELoadingProgress.LoadMainHub, new BootstrapStateLoadMainHub(this));
            StateBehaviours.Add((int)BootstrapModel.ELoadingProgress.MainHub, new BootstrapStateMainHub(this));
            StateBehaviours.Add((int)BootstrapModel.ELoadingProgress.GamePlay, new BootstrapStateGamePlay(this));
            
            _bootstrapModel.LoadingProgress.Subscribe(OnLoadingProgressChanged).AddTo(Disposables);
        }

        private void OnLoadingProgressChanged(BootstrapModel.ELoadingProgress loadingProgress)
        {
            _view.ProgressBar.value = (float)loadingProgress / 100;

            GoToState((int)loadingProgress);
        }

        private void OnReload()
        {
            _view.Show();

            UnloadAllScenesExceptSignal.UnloadAllExcept(SignalBus, Scenes.Bootstrap).Done
            (
                () =>
                {
                    _bootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.LoadPopup;
                },
                exception =>
                {
                    Debug.LogError("Error While Reloading: " + exception.ToString());
                }
            );
        }

        private void OnLoadingStart()
        {
            _view.Show();
        }
    }
}

