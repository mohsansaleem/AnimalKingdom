using PG.animalKingdom.view.scene;
using PG.Core.installer;

namespace PG.animalKingdom.view
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateLoadMainHub : BootstrapState
        {
            public BootstrapStateLoadMainHub(BootstrapMediator mediator):base(mediator)
            {
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();

                LoadUnloadScenesSignal.Load(SignalBus, new[] { Scenes.MainHub }).Done
                (
                    () =>
                    {
                        BootstrapModel.LoadingProgress.Value = model.scene.BootstrapModel.ELoadingProgress.MainHub;
                    }
                );
            }
        }
    }
}