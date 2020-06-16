using PG.AnimalKingdom.Contexts.Popup.data;
using PG.AnimalKingdom.Contexts.Popup.sub;
using PG.AnimalKingdom.Installer;
using PG.AnimalKingdom.Views.Popup;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Contexts.Popup
{
    public class PopupInstaller : MonoInstaller
    {
        [SerializeField]
        private PopupView _popupView;

        [Inject] private ProjectContextInstaller.Settings _settings;

        public override void InstallBindings()
        {
            Container.BindFactory<PopupData, PopupDialogFacade, PopupDialogFacade.Factory>()
                // We could just use FromMonoPoolableMemoryPool here instead, but
                // for IL2CPP to work we need our pool class to be used explicitly here
                .FromPoolableMemoryPool<PopupData, PopupDialogFacade, PopupDialogFacadePool>(poolBinder => poolBinder
                    // Spawn 1 PopupDialog right off the bat so that we don't incur spikes at runtime
                    .WithInitialSize(1)
                    .FromSubContainerResolve()
                    // We have attached a GameObject Context component to the prefab.
                    .ByNewContextPrefab(_settings.PopupDialogPrefab)
                    // Place each PopupDialog under an PopupDialogsContainer game object
                    .UnderTransform(_popupView.PopupDialogsContainer));

            Container.Bind<PopupDialogRegistry>().AsSingle();

            Container.BindInstances(_popupView);
            Container.BindInterfacesTo<PopupMediator>().AsSingle();

            // 1. Bind Spawners/Mediators here.
            // Container.BindInstance([InstanceReference/New Instance]) // This will take an Instance and Bind to Container
            // Container.BindInterfacesTo<PopupMediator>() // This will auto create an Instance and bind it to Container.

            // 2. Bind Factories.
        }

        // We could just use FromMonoPoolableMemoryPool above, but we have to use these instead
        // for IL2CPP to work
        class PopupDialogFacadePool : MonoPoolableMemoryPool<PopupData, IMemoryPool, PopupDialogFacade>
        {
        }
    }
}
