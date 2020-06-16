using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Views.Hud;
using PG.Core.Context;

namespace PG.AnimalKingdom.Contexts.Hud
{
    public partial class HudMediator
    {
        public class HudState : StateBehaviour
        {
            protected readonly Hud.HudMediator Mediator;
            protected readonly HudModel HudModel;
            protected readonly HudView View;

            public HudState(Hud.HudMediator mediator)
            {
                this.Mediator = mediator;
                this.HudModel = mediator._hudModel;
                this.View = mediator._view;
            }
        }
    }
}
