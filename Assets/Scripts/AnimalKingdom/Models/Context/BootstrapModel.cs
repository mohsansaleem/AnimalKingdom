using UniRx;

namespace PG.AnimalKingdom.Models.Context
{
    public class BootstrapModel
    {
        public enum ELoadingProgress
        {
            NotLoaded = -1,
            Zero = 0,
            PopupLoaded = 20,
            MetaNotFound = 25,
            StaticDataLoaded = 30,
            UserNotFound = 50,
            DataSeeded = 70,
            HudLoaded = 80,
            MainHub = 100,
            GamePlay = 110
        }

        public ReactiveProperty<ELoadingProgress> LoadingProgress;

        public BootstrapModel()
        {
            LoadingProgress = new ReactiveProperty<ELoadingProgress>(ELoadingProgress.Zero);
        }
    }
}

