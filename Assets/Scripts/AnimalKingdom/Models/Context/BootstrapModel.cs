using UniRx;

namespace PG.AnimalKingdom.Models.Context
{
    public class BootstrapModel
    {
        public enum ELoadingProgress
        {
            NotLoaded = -1,
            LoadPopup = 0,
            LoadStaticData = 20,
            CreateMetaData = 25,
            LoadUserData = 30,
            CreateUserData = 50,
            LoadHud = 70,
            LoadMainHub = 80,
            MainHub = 100,
            GamePlay = 110
        }

        public ReactiveProperty<ELoadingProgress> LoadingProgress;

        public BootstrapModel()
        {
            LoadingProgress = new ReactiveProperty<ELoadingProgress>(ELoadingProgress.LoadPopup);
        }
    }
}

