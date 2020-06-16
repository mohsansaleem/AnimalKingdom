using PG.AnimalKingdom.Contexts.Popup.data;
using PG.AnimalKingdom.Installer;
using PG.AnimalKingdom.Views.Popup;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Contexts.Popup.sub
{
    public class PopupDialogInstaller : MonoInstaller<PopupDialogInstaller>
    {
        // We have to use the reference that is why we are using it here 
        // and Binding it through the ZenjectBinding Component
        [SerializeField] private PopupDialogView _view;
        [Inject] private ProjectContextInstaller.Settings _settings;

        public override void InstallBindings()
        {
            // We can bind the ViewInstance here by using the reference or also can go with ZenjectBinding Component.

            Container.BindFactory<PopupButtonData, PopupData, PopupButtonFacade, PopupButtonFacade.Factory>()
                // We could just use FromMonoPoolableMemoryPool here instead, but
                // for IL2CPP to work we need our pool class to be used explicitly here
                .FromPoolableMemoryPool<PopupButtonData, PopupData, PopupButtonFacade, PopupButtonFacadePool>(
                    poolBinder => poolBinder
                        // Spawn 1 PopupButtonDialog right off the bat so that we don't incur spikes at runtime
                        .WithInitialSize(2)
                        // For SubContainer stuff if we have sub Containers in targeted container.
                        //.FromSubContainerResolve()
                        // Having the reference of the Component in the Facade and they will be created with Prefab so no need to Inject anything.
                        .FromComponentInNewPrefab(_settings.PopupButtonPrefab)
                        // We can use Installer if there is stuff to Inject and other stuff like Factories and Signals etc.
                        //.ByNewPrefabInstaller<PopupButtonInstaller>(_settings.PopupButtonPrefab)
                        // For Small stuff Installation we can use the Method. Sample method in the function below.
                        //.ByNewPrefabMethod(_settings.PopupButtonPrefab, InstallButton)
                        .UnderTransform(_view.ButtonsPanel));
                        //.UnderTransformGroup("Test"));

            Container.Bind<PopupButtonRegistry>().AsSingle();
        }

        // No need to Install from Method or Installer class if there are not any new stuff to Inject.
        // So Just passing the View(UIButton) reference to the 
        //void InstallButton(DiContainer subContainer)
        //{
        //    // Nothing to Inject. Already Injected from Zenject Binding. As we did for View.
        //    // Instead of keeping the reference in installer and then binding it in Installer we are just passing it to Zenject Binding Component.

        //    //subContainer.Bind<PopupButtonFacade>().FromNewComponentOnRoot().AsCached();
        //    //subContainer.Bind<UIButton>().FromNewComponentOnRoot().AsCached().NonLazy();

        //    // Bind extra stuff if there is any.
        //}

        class PopupButtonFacadePool : MonoPoolableMemoryPool<PopupButtonData, PopupData, IMemoryPool, PopupButtonFacade>
        {
        }
    }
}
