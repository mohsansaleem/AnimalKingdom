using game.animalKingdom.model.scene;
using game.core;

namespace game.animalKingdom.view
{
    public partial class MainHubMediator
    {
        public class MainHubState : StateBehaviour
        {
            protected readonly MainHubMediator Mediator;
            protected readonly MainHubModel MainHubModel;
            protected readonly MainHubView View;

            public MainHubState(MainHubMediator mediator)
            {
                this.Mediator = mediator;
                this.MainHubModel = mediator._mainHubModel;
                this.View = mediator._view;
            }
        }
    }
}
