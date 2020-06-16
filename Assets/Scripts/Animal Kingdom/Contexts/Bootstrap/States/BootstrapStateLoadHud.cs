using PG.animalKingdom.view.scene;
using PG.Core.installer;
using UnityEngine;

namespace PG.animalKingdom.view
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateLoadHud : BootstrapState
        {
            public BootstrapStateLoadHud(BootstrapMediator mediator):base(mediator)
            {
                
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();

                LoadUnloadScenesSignal.Load(Mediator.SignalBus, Scenes.Hud).Done
                (
                    () =>
                    {
                        BootstrapModel.LoadingProgress.Value = model.scene.BootstrapModel.ELoadingProgress.HudLoaded;
                    },
                exception =>
                {
                    Debug.LogError("Exception: "+exception.ToString());
                }
                );
            }
        }
    }
}