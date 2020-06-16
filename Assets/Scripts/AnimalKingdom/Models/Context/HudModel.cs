using UniRx;

namespace PG.AnimalKingdom.Models.Context
{
    public class HudModel
    {
        public enum EHudState
        {
            Hidden,
            GamePlay,
            Popup
        }

        public ReactiveProperty<EHudState> HudState;

        public HudModel()
        {
            HudState = new ReactiveProperty<EHudState>(EHudState.Hidden);
        }
    }
}

