namespace PG.AnimalKingdom.Contexts.Hud
{
    public partial class HudMediator
    {
        public class HudStateGamePlay : HudState
        {
            public HudStateGamePlay(Hud.HudMediator mediator):base(mediator)
            {

            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();
                
                this.View.Show();
            }
        }
    }
}