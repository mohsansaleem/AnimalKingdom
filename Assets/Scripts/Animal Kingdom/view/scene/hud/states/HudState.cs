using game.animalKingdom.model.scene;
using game.core;

namespace game.animalKingdom.view
{
    public partial class HudMediator
    {
        public class HudState : StateBehaviour
        {
            protected readonly HudMediator Mediator;
            protected readonly HudModel HudModel;
            protected readonly HudView View;

            public HudState(HudMediator mediator)
            {
                this.Mediator = mediator;
                this.HudModel = mediator._hudModel;
                this.View = mediator._view;
            }
        }
    }
}
