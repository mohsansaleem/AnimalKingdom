using game.animalKingdom.model.scene;
using UnityEngine;
using Zenject;

namespace game.animalKingdom.view
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
