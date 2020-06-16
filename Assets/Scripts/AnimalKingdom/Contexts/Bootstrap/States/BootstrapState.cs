using PG.AnimalKingdom.Installer;
using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Views.Bootstrap;
using PG.Core.Context;
using Zenject;

namespace PG.AnimalKingdom.Contexts.Bootstrap
{
    public partial class BootstrapMediator
    {
        public class BootstrapState : StateBehaviour
        {
            protected readonly Bootstrap.BootstrapMediator Mediator;
            protected readonly BootstrapModel BootstrapModel;
            protected readonly BootstrapView View;
            protected readonly SignalBus SignalBus;

            protected readonly ProjectContextInstaller.Settings GameSettings;

            public BootstrapState(Bootstrap.BootstrapMediator mediator)
            {
                this.Mediator = mediator;
                this.BootstrapModel = mediator._bootstrapModel;
                this.View = mediator._view;
                this.SignalBus = mediator.SignalBus;

                this.GameSettings = mediator._gameSettings;
            }
        }
    }
}
