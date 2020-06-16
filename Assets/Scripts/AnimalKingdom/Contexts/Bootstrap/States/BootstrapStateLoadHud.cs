using PG.AnimalKingdom.Models.Context;
using PG.Core.installer;
using UnityEngine;

namespace PG.AnimalKingdom.Contexts.Bootstrap
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateLoadHud : BootstrapState
        {
            public BootstrapStateLoadHud(Bootstrap.BootstrapMediator mediator):base(mediator)
            {
                
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();

                LoadUnloadScenesSignal.Load(Mediator.SignalBus, Scenes.Hud).Done
                (
                    () =>
                    {
                        BootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.HudLoaded;
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