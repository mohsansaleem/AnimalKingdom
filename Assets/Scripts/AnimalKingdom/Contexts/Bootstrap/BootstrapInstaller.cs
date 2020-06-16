using PG.AnimalKingdom.Commands;
using PG.AnimalKingdom.Views.Bootstrap;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Contexts.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField]
        private BootstrapView _view;

        public override void InstallBindings()
        {
            Container.DeclareSignal<LoadStaticDataSignal>().RunAsync();
            Container.BindSignal<LoadStaticDataSignal>().ToMethod<LoadStaticDataCommand>(x => x.Execute).FromNew();

            Container.DeclareSignal<CreateMetaDataSignal>().RunAsync();
            Container.BindSignal<CreateMetaDataSignal>().ToMethod<CreateMetaDataCommand>(x => x.Execute).FromNew();
            
            Container.DeclareSignal<LoadUserDataSignal>().RunAsync();
            Container.BindSignal<LoadUserDataSignal>().ToMethod<LoadUserDataCommand>(x => x.Execute).FromNew();

            Container.DeclareSignal<SaveUserDataSignal>().RunAsync();
            Container.BindSignal<SaveUserDataSignal>().ToMethod<SaveUserDataCommand>(x => x.Execute).FromNew();

            Container.DeclareSignal<CreateUserDataSignal>().RunAsync();
            Container.BindSignal<CreateUserDataSignal>().ToMethod<CreateUserDataCommand>(x => x.Execute).FromNew();

            Container.BindInstances(_view);
            Container.BindInterfacesTo<BootstrapMediator>().AsSingle();
        }
    }
}
