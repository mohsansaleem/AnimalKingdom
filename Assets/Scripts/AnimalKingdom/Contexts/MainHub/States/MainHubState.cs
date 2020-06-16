using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Views.MainHub;
using PG.Core.Context;

namespace PG.AnimalKingdom.Contexts.MainHub
{
    public partial class MainHubMediator
    {
        public class MainHubState : StateBehaviour
        {
            protected readonly MainHub.MainHubMediator Mediator;
            protected readonly MainHubModel MainHubModel;
            protected readonly MainHubView View;

            public MainHubState(MainHub.MainHubMediator mediator)
            {
                this.Mediator = mediator;
                this.MainHubModel = mediator._mainHubModel;
                this.View = mediator._view;
            }
        }
    }
}
