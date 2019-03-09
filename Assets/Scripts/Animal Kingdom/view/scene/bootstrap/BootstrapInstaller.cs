using game.animalKingdom.command;
using game.animalKingdom.installer;
using UnityEngine;
using Zenject;

namespace game.animalKingdom.view
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField]
        private BootstrapView _view;

        public override void InstallBindings()
        {
            Container.DeclareSignal<LoadStaticDataSignal>().RunAsync();
            Container.BindSignal<LoadStaticDataSignal>().ToMethod<LoadStaticDataCommand>((x, promise) => x.Execute(promise)).FromNew();

            Container.DeclareSignal<CreateMetaDataSignal>().RunAsync();
            Container.BindSignal<CreateMetaDataSignal>().ToMethod<CreateMetaDataCommand>((x, param) => x.Execute(param)).FromNew();
            
            Container.DeclareSignal<LoadUserDataSignal>().RunAsync();
            Container.BindSignal<LoadUserDataSignal>().ToMethod<LoadUserDataCommand>((x, promise) => x.Execute(promise)).FromNew();

            Container.DeclareSignal<SaveUserDataSignal>().RunAsync();
            Container.BindSignal<SaveUserDataSignal>().ToMethod<SaveUserDataCommand>((x, y) => x.Execute(y)).FromNew();

            Container.DeclareSignal<CreateUserDataSignal>().RunAsync();
            Container.BindSignal<CreateUserDataSignal>().ToMethod<CreateUserDataCommand>((x, param) => x.Execute(param)).FromNew();

            Container.BindInstances(_view);
            Container.BindInterfacesTo<BootstrapMediator>().AsSingle();
        }
    }
}
