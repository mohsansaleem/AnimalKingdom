using game.animalKingdom.installer;
using game.animalKingdom.model.scene;
using game.core;
using Zenject;

namespace game.animalKingdom.view
{
    public partial class BootstrapMediator
    {
        public class BootstrapState : StateBehaviour
        {
            protected readonly BootstrapMediator Mediator;
            protected readonly BootstrapModel BootstrapModel;
            protected readonly BootstrapView View;
            protected readonly SignalBus SignalBus;

            protected readonly ProjectContextInstaller.Settings GameSettings;

            public BootstrapState(BootstrapMediator mediator)
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
