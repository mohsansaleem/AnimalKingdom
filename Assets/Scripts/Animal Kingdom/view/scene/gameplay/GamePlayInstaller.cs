using game.animalKingdom.command;
using game.animalKingdom.installer;
using pg.core.assets;
using UnityEngine;
using Zenject;

namespace game.animalKingdom.view
{
    public class GamePlayInstaller : MonoInstaller
    {
        [SerializeField] private Transform _prefabContainer;

        [Inject] private ProjectContextInstaller.Settings _settings;

        public override void InstallBindings()
        {
            CreateAnimalsPool();
            
            Container.DeclareSignal<ResetGameSignal>().RunAsync();
            Container.BindSignal<ResetGameSignal>().ToMethod<ResetGameCommand>((x, y) => x.Execute(y)).FromNew();
            
            Container.DeclareSignal<GameTickSignal>().RunAsync();
            Container.BindSignal<GameTickSignal>().ToMethod<GameTickCommand>((x, y) => x.Execute(y)).FromNew();
            
            Container.DeclareSignal<UnloadGroupSignal>().RunAsync();
            Container.BindSignal<UnloadGroupSignal>().ToMethod<UnloadGroupCommand>((x, y) => x.Execute(y)).FromNew();

            Container.DeclareSignal<SpawnIfSpaceSignal>().RunAsync();
            Container.BindSignal<SpawnIfSpaceSignal>().ToMethod<SpawnIfSpaceCommand>((x, y) => x.Execute(y)).FromNew();
            
            Container.DeclareSignal<AddAnimalToGroupSignal>().RunAsync();
            Container.BindSignal<AddAnimalToGroupSignal>().ToMethod<AddAnimalToGroupCommand>((x, y) => x.Execute(y)).FromNew();
            
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