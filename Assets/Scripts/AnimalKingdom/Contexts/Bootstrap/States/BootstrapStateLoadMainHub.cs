using PG.AnimalKingdom.Models.Context;
using PG.Core.installer;

namespace PG.AnimalKingdom.Contexts.Bootstrap
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateLoadMainHub : BootstrapState
        {
            public BootstrapStateLoadMainHub(Bootstrap.BootstrapMediator mediator):base(mediator)
            {
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();

                LoadUnloadScenesSignal.Load(SignalBus, new[] { Scenes.MainHub }).Done
                (
                    () =>
                    {
                        BootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.MainHub;
                    }
                );
            }
        }
    }
}