namespace PG.animalKingdom.view
{
    public partial class HudMediator
    {
        public class HudStateGamePlay : HudState
        {
            public HudStateGamePlay(HudMediator mediator):base(mediator)
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