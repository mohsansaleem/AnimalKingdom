using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Views.MainHub;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Contexts.MainHub
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
