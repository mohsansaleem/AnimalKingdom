using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Views.Hud;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Contexts.Hud
{
    public class HudInstaller : MonoInstaller
    {
        [SerializeField]
        public HudView HudView;

        public override void InstallBindings()
        {
            Container.BindInstance(HudView);
            Container.Bind<HudModel>().AsSingle();
            Container.BindInterfacesTo<HudMediator>().AsSingle();
        }
    }
}
