using UniRx;

namespace PG.AnimalKingdom.Models.Context
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

