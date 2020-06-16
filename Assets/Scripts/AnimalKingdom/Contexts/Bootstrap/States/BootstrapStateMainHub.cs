namespace PG.AnimalKingdom.Contexts.Bootstrap
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateMainHub : BootstrapState
        {
            public BootstrapStateMainHub(Bootstrap.BootstrapMediator mediator):base(mediator)
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