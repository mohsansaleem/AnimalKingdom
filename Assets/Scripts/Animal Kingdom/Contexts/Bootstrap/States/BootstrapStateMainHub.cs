namespace PG.animalKingdom.view
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateMainHub : BootstrapState
        {
            public BootstrapStateMainHub(BootstrapMediator mediator):base(mediator)
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