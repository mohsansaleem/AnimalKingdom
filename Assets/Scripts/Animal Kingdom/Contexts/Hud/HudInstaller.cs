using PG.animalKingdom.model.scene;
using UnityEngine;
using Zenject;

namespace PG.animalKingdom.view
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
