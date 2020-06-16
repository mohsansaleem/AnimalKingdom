using PG.AnimalKingdom.Commands;
using PG.AnimalKingdom.Installer;
using PG.AnimalKingdom.Views.GamePlay;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Contexts.GamePlay
{
    public class GamePlayInstaller : MonoInstaller
    {
        [SerializeField] private Transform _prefabContainer;

        [Inject] private ProjectContextInstaller.Settings _settings;

        public override void InstallBindings()
        {
            CreateAnimalsPool();
            
            Container.DeclareSignal<ResetGameSignal>().RunAsync();
            Container.BindSignal<ResetGameSignal>().ToMethod<ResetGameCommand>(x => x.Execute).FromNew();
            
            Container.DeclareSignal<GameTickSignal>().RunAsync();
            Container.BindSignal<GameTickSignal>().ToMethod<GameTickCommand>(x => x.Execute).FromNew();
            
            Container.DeclareSignal<UnloadGroupSignal>().RunAsync();
            Container.BindSignal<UnloadGroupSignal>().ToMethod<UnloadGroupCommand>(x => x.Execute).FromNew();

            Container.DeclareSignal<SpawnIfSpaceSignal>().RunAsync();
            Container.BindSignal<SpawnIfSpaceSignal>().ToMethod<SpawnIfSpaceCommand>(x => x.Execute).FromNew();
            
            Container.DeclareSignal<AddAnimalToGroupSignal>().RunAsync();
            Container.BindSignal<AddAnimalToGroupSignal>().ToMethod<AddAnimalToGroupCommand>(x => x.Execute).FromNew();
            
            Container.BindInterfacesTo<GamePlayMediator>().AsSingle();
        }

        private void CreateAnimalsPool()
        {
            // Instantiating a new prefab memory pool for Animals
            AnimalPool prefabPool = Container.Instantiate<AnimalPool>(new object[]
                {
                    new MemoryPoolSettings()
                    {
                        MaxSize = 5,
                        InitialSize = 2
                    },
                    //new MemoryPoolSettings(),
                    new AnimalFactory(Container)
                }
            );

            // set parent transform for prefab memory pool
            prefabPool.SetTransformGroup(_prefabContainer);
            Container.BindInstance(prefabPool).AsSingle();
        }
    }
}