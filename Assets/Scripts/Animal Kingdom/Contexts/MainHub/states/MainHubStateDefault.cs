using PG.animalKingdom.model.scene;
using PG.animalKingdom.view.scene;
using PG.Core.installer;

namespace PG.animalKingdom.view
{
    public partial class MainHubMediator
    {
        public class MainHubStateDefault : MainHubState
        {
            public MainHubStateDefault(MainHubMediator mediator):base(mediator)
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