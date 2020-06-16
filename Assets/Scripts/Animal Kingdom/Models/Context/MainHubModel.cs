using UniRx;

namespace PG.animalKingdom.model.scene
{
    public class MainHubModel
    {
        public enum EMainHubState
        {
            Default
        }

        public ReactiveProperty<EMainHubState> MainHubState;

        public MainHubModel()
        {
            MainHubState = new ReactiveProperty<EMainHubState>(EMainHubState.Default);
        }
    }
}

