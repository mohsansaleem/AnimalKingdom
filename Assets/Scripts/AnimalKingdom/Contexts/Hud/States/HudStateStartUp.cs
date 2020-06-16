namespace PG.AnimalKingdom.Contexts.Hud
{
    public partial class HudMediator
    {
        public class HudStateHidden : HudState
        {
            public HudStateHidden(Hud.HudMediator mediator):base(mediator)
            {
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();
                
                this.View.Hide();
            }
        }
    }
}