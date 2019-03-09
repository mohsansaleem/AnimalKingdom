namespace game.animalKingdom.view
{
    public partial class HudMediator
    {
        public class HudStateHidden : HudState
        {
            public HudStateHidden(HudMediator mediator):base(mediator)
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