﻿using System;
using PG.animalKingdom.installer;
using PG.AnimalKingdom.Installer;
using PG.animalKingdom.model;
using PG.animalKingdom.model.remote;
using PG.animalKingdom.model.scene;
using PG.animalKingdom.view.scene;
using PG.Core;
using PG.Core.Context;
using PG.Core.installer;
using UniRx;
using UnityEngine;
using Zenject;

namespace PG.animalKingdom.view
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

            StateBehaviours.Add(typeof(BootstrapStateLoadPopup), new BootstrapStateLoadPopup(this));
            StateBehaviours.Add(typeof(BootstrapStateLoadStaticData), new BootstrapStateLoadStaticData(this));
            StateBehaviours.Add(typeof(BootstrapStateCreateMetaData), new BootstrapStateCreateMetaData(this)); // Temporary State for creating MetaData
            StateBehaviours.Add(typeof(BootstrapStateLoadUserData), new BootstrapStateLoadUserData(this));
            StateBehaviours.Add(typeof(BootstrapStateCreateUserData), new BootstrapStateCreateUserData(this));
            StateBehaviours.Add(typeof(BootstrapStateLoadHud), new BootstrapStateLoadHud(this));
            StateBehaviours.Add(typeof(BootstrapStateLoadMainHub), new BootstrapStateLoadMainHub(this));
            StateBehaviours.Add(typeof(BootstrapStateMainHub), new BootstrapStateMainHub(this));
            StateBehaviours.Add(typeof(BootstrapStateGamePlay), new BootstrapStateGamePlay(this));
            
            _bootstrapModel.LoadingProgress.Subscribe(OnLoadingProgressChanged).AddTo(Disposables);
        }

        private void OnLoadingProgressChanged(BootstrapModel.ELoadingProgress loadingProgress)
        {
            _view.ProgressBar.value = (float)loadingProgress / 100;


            Type targetType = null;
            switch (loadingProgress)
            {
                case BootstrapModel.ELoadingProgress.Zero:
                    targetType = typeof(BootstrapStateLoadPopup);
                    break;
                case BootstrapModel.ELoadingProgress.PopupLoaded:
                    targetType = typeof(BootstrapStateLoadStaticData);
                    break;
                case BootstrapModel.ELoadingProgress.MetaNotFound:
                    targetType = typeof(BootstrapStateCreateMetaData);
                    break;
                case BootstrapModel.ELoadingProgress.StaticDataLoaded:
                    targetType = typeof(BootstrapStateLoadUserData);
                    break;
                case BootstrapModel.ELoadingProgress.UserNotFound:
                    targetType = typeof(BootstrapStateCreateUserData);
                    break;
                case BootstrapModel.ELoadingProgress.DataSeeded:
                    targetType = typeof(BootstrapStateLoadHud);
                    break;
                case BootstrapModel.ELoadingProgress.HudLoaded:
                    targetType = typeof(BootstrapStateLoadMainHub);
                    break;
                case BootstrapModel.ELoadingProgress.MainHub:
                    targetType = typeof(BootstrapStateMainHub);
                    break;
                case BootstrapModel.ELoadingProgress.GamePlay:
                    targetType = typeof(BootstrapStateGamePlay);
                    break;
            }

            if (targetType != null &&
                (CurrentStateBehaviour == null ||
                 targetType != CurrentStateBehaviour.GetType()))
            {
                GoToState(targetType);
            }
        }

        private void OnReload()
        {
            _view.Show();

            UnloadAllScenesExceptSignal.UnloadAllExcept(SignalBus, Scenes.Bootstrap).Done
            (
                () =>
                {
                    _bootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.Zero;
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

