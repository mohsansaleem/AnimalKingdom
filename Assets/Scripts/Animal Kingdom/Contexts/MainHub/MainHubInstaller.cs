using PG.animalKingdom.model.scene;
using UnityEngine;
using Zenject;

namespace PG.animalKingdom.view
{
    public class MainHubInstaller : MonoInstaller
    {
        [SerializeField]
        public MainHubView MainHubView;

        public override void InstallBindings()
        {
            Container.Bind<MainHubModel>().AsSingle();

            Container.BindInstance(MainHubView);
            Container.BindInterfacesTo<MainHubMediator>().AsSingle();
        }
    }
}
