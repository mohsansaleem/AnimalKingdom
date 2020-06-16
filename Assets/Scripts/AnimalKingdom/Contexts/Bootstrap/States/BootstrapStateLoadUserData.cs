using PG.AnimalKingdom.Models.Context;

namespace PG.AnimalKingdom.Contexts.Bootstrap
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateLoadUserData : BootstrapState
        {
            public BootstrapStateLoadUserData(Bootstrap.BootstrapMediator mediator) : base(mediator)
            {
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();
                
                LoadUserDataSignal.LoadUserData(SignalBus).Then(
                    () =>
                    {
                        BootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.LoadHud;
                    }
                ).Catch(e =>
                {
                    BootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.CreateUserData;
                });
            }
        }
    }
}