using PG.animalKingdom.installer;
using PG.animalKingdom.model.scene;

namespace PG.animalKingdom.view
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateLoadUserData : BootstrapState
        {
            public BootstrapStateLoadUserData(BootstrapMediator mediator) : base(mediator)
            {
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();
                
                LoadUserDataSignal.LoadUserData(SignalBus).Then(
                    () =>
                    {
                        BootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.DataSeeded;
                    }
                ).Catch(e =>
                {
                    BootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.UserNotFound;
                });
            }
        }
    }
}