using System;
using System.Collections.Generic;
using System.Linq;
using game.animalKingdom.installer;
using game.animalKingdom.model.remote;
using game.animalKingdom.model.scene;
using game.animalKingdom.view.scene;
using game.core;
using game.core.installer;
using pg.core.assets;
using RSG;
using UniRx;
using UnityEngine;
using Zenject;

namespace game.animalKingdom.view
{
    public partial class GamePlayMediator : StateMachineMediator
    {
        [Inject] public ProjectContextInstaller.Settings _projectSettings;
        [Inject] private readonly DiContainer _container;

        [Inject] private readonly GamePlayView _view;
        [Inject] private Camera _camera;

        [Inject] private readonly BootstrapModel _bootstrapModel;
        [Inject] private readonly GamePlayModel _gamePlayModel;
        [Inject] private readonly RemoteDataModel _remoteDataModel;

        [Inject] private readonly AnimalPool _animalsPool;

        // GameObjects
        private HeroView _hero;
        private Dictionary<long, AnimalView> _animalViews = new Dictionary<long, AnimalView>();

        // Variables
        private Vector3 _destination;

        public override void Initialize()
        {
            base.Initialize();

            StateBehaviours.Add(typeof(GamePlayStateLoad), new GamePlayStateLoad(this));
            StateBehaviours.Add(typeof(GamePlayStateGathering), new GamePlayStateGathering(this));
            StateBehaviours.Add(typeof(GamePlayStateUnloading), new GamePlayStateUnloading(this));
            StateBehaviours.Add(typeof(GamePlayStatePause), new GamePlayStatePause(this));

            OnGamePlayStateChanged(GamePlayModel.EGamePlayState.Load);

            // Observing Remote Data.
            _remoteDataModel.AnimalRemoteDatas.ObserveAdd().Subscribe(OnAnimalAdd).AddTo(Disposables);
            _remoteDataModel.AnimalRemoteDatas.ObserveRemove().Subscribe(OnAnimalRemove).AddTo(Disposables);
            _remoteDataModel.HeroRemoteModel.Subscribe(OnHeroAdded).AddTo(Disposables);
            
            // Resetting GameTime
            SignalBus.Fire<ResetGameSignal>();
            
            // Check after each three second for new Animals.
            Observable.Timer(TimeSpan.FromSeconds(3)).Repeat()
                .Subscribe((interval) => SignalBus.Fire<SpawnIfSpaceSignal>())
                .AddTo(Disposables);
            
            // Timer Tick
            Observable.Timer(TimeSpan.FromSeconds(1)).Repeat()
                .Subscribe((interval) => SignalBus.Fire<GameTickSignal>())
                .AddTo(Disposables);
            
            _gamePlayModel.GamePlayState.Subscribe(OnGamePlayStateChanged).AddTo(Disposables);
            _view.BackButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnHeroAdded(HeroRemoteDataModel heroModel)
        {
            if (heroModel != null)
            {
                SpawnHero(heroModel).Done((v) =>
                {
                    _hero = v;
                    heroModel.Group.ObserveAdd().Subscribe(OnAnimalAddToGroup).AddTo(Disposables);
                });
            }
        }

        private void OnAnimalAdd(DictionaryAddEvent<long, AnimalRemoteDataModel> obj)
        {
            SpawnAnimal(obj.Value).Catch(exception => Debug.LogError(exception));
        }

        private void OnAnimalRemove(DictionaryRemoveEvent<long, AnimalRemoteDataModel> obj)
        {
            DeSpawnAnimal(obj.Value);
        }

        private IPromise<HeroView> SpawnHero(HeroRemoteDataModel hero)
        {
            Promise<HeroView> promise = new Promise<HeroView>();

            GameObject instance = _container.InstantiatePrefab(_projectSettings.HeroPrefab);
            HeroView heroView = instance.GetComponent<HeroView>() ??
                                _container.InstantiateComponent<HeroView>(instance);

            heroView.Initialize(hero);

            promise.Resolve(heroView);

            return promise;
        }

        private IPromise<AnimalView> SpawnAnimal(AnimalRemoteDataModel animalModel)
        {
            return _animalsPool.Spawn<AnimalView>(
                _projectSettings.AnimalsPrefabs.First(a => a.Type.Equals(animalModel.RemoteData.AnimalType)),
                new AnimalViewParams()
                {
                    parent = _view.AnimalsRoot,
                    AnimalModel = animalModel
                }
            ).Then(v => _animalViews.Add(animalModel.RemoteData.Id, v));
        }

        private void DeSpawnAnimal(AnimalRemoteDataModel animalModel)
        {
            _animalsPool.Despawn<AnimalView>(
                _projectSettings.AnimalsPrefabs.First(a => a.Type.Equals(animalModel.RemoteData.AnimalType)),
                _animalViews[animalModel.RemoteData.Id]);
        }

        private void AddAnimalToGroup(AnimalView animalView)
        {
            AnimalRemoteDataModel model = (AnimalRemoteDataModel) animalView.Model;
            
            AddAnimalToGroupSignal.AddAnimal(SignalBus, model);
        }
        
        private void OnAnimalAddToGroup(CollectionAddEvent<EntityRemoteDataModel> obj)
        {
            var model = (AnimalRemoteDataModel) obj.Value;
            
            _animalViews[model.RemoteData.Id].AnimalState = EAnimalState.Follow;
            
            CalculateSpeedAndMove();
        }

        public void CalculateSpeedAndMove()
        {
            float minSpeed = _hero.Model.Speed;

            var hero = _remoteDataModel.HeroModel;
            
            if (hero.Group != null)
            {
                for (int i = 0; i < hero.Group.Count; i++)
                {
                    if (hero.Group[i].Speed < minSpeed)
                    {
                        minSpeed = hero.Group[i].Speed;
                    }
                }

                foreach (var pair in hero.Group)
                {
                    _animalViews[((AnimalRemoteDataModel) pair).RemoteData.Id].Move(_destination, minSpeed);
                }
            }

            _hero.Move(_destination, minSpeed);
        }

        private void OnBackButtonClicked()
        {
            UnloadSceneSignal.Unload(SignalBus, Scenes.GamePlay)
                .Done((() => _bootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.MainHub));
        }

        private void OnGamePlayStateChanged(GamePlayModel.EGamePlayState gamePlayState)
        {
            Type targetType = null;
            switch (gamePlayState)
            {
                case GamePlayModel.EGamePlayState.Load:
                    targetType = typeof(GamePlayStateLoad);
                    break;
                case GamePlayModel.EGamePlayState.Gathering:
                    targetType = typeof(GamePlayStateGathering);
                    break;
                case GamePlayModel.EGamePlayState.Unloading:
                    targetType = typeof(GamePlayStateUnloading);
                    break;
                case GamePlayModel.EGamePlayState.Pause:
                    targetType = typeof(GamePlayStatePause);
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