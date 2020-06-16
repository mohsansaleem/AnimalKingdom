using PG.AnimalKingdom.Models.Context;
using PG.Core.installer;

namespace PG.AnimalKingdom.Contexts.MainHub
{
    public partial class MainHubMediator
    {
        public class MainHubStateDefault : MainHubState
        {
            public MainHubStateDefault(MainHub.MainHubMediator mediator):base(mediator)
            {

            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();

                View.PlayButton.onClick.AddListener(OnPlayClicked);
            }

            private void OnPlayClicked()
            {
                LoadUnloadScenesSignal.Load(Mediator.SignalBus, Scenes.GamePlay).Done
                (
                    () => { Mediator._bootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.GamePlay; },
                    exception =>
                    {
                        UnityEngine.Debug.LogError("Exception: " + exception.ToString());
                    }
                );
            }

            public override void OnStateExit()
            {
                base.OnStateExit();

                View.PlayButton.onClick.RemoveListener(OnPlayClicked);
            }
        }
    }
}