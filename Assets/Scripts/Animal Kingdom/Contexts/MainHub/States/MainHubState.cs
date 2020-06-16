using PG.animalKingdom.model.scene;
using PG.Core;
using PG.Core.Context;

namespace PG.animalKingdom.view
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
