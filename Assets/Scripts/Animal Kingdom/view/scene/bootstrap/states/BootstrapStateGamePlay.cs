namespace game.animalKingdom.view
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateGamePlay : BootstrapState
        {
            public BootstrapStateGamePlay(BootstrapMediator mediator):base(mediator)
            {
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();
                
                View.Hide();
            }
        }
    }
}