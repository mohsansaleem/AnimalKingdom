namespace PG.AnimalKingdom.Contexts.GamePlay
{
    public partial class GamePlayMediator
    {
        public class GamePlayStateUnloading : GamePlayState
        {
            public GamePlayStateUnloading(GamePlayMediator mediator) : base(mediator)
            {
                
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();
             
                Mediator.SignalBus.Fire<UnloadGroupSignal>();                
            }
        }
    }
}