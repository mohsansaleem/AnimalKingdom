using UniRx;

namespace PG.animalKingdom.model.scene
{
    public class GamePlayModel
    {
        public enum EGamePlayState
        {
            Load = 0,
            Gathering,
            Unloading,
            Pause
        }

        public readonly ReactiveProperty<EGamePlayState> GamePlayState;

        public GamePlayModel()
        {
            GamePlayState = new ReactiveProperty<EGamePlayState>(EGamePlayState.Load);
        }
    }
}

