using PG.animalKingdom.model.data;
using UniRx;
using Zenject;

namespace PG.animalKingdom.model.remote
{
    public class AnimalRemoteDataModel : EntityRemoteDataModel
    {
        [Inject] private readonly StaticDataModel _staticDataModel;

        private CompositeDisposable _disposables;

        public readonly ReactiveProperty<AnimalRemoteData> AnimalRemoteData;

        public AnimalRemoteDataModel()
        {
            AnimalRemoteData = new ReactiveProperty<AnimalRemoteData>();

            _disposables = new CompositeDisposable();
        }

        public override float Speed => AnimalRemoteData.Value.Speed;
        public override float PatrolSpeed => AnimalRemoteData.Value.AnimalData.PatrolSpeed;
        public AnimalData Data => AnimalRemoteData.Value.AnimalData;
        public AnimalRemoteData RemoteData => AnimalRemoteData.Value;
        
        public void SeedAnimalRemoteData(AnimalRemoteData animalRemoteData)
        {
            AnimalRemoteData.Value = animalRemoteData;
            CurrentPosition = RemoteData.CurrentPosition;
        }

        public class Factory : PlaceholderFactory<AnimalRemoteDataModel>
        {
        }
    }
}