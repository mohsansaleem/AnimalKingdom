using System.Linq;
using PG.AnimalKingdom.Models.Data;
using UniRx;
using Zenject;

namespace PG.AnimalKingdom.Models.Remote
{
    public class RemoteDataModel
    {
        [Inject] private readonly StaticDataModel _staticDataModel;
        [Inject] private HeroRemoteDataModel.Factory _heroFactory;
        [Inject] private AnimalRemoteDataModel.Factory _animalFactory;

        public UserData UserData { get; private set; }

        public readonly ReactiveProperty<double> Coins;
        public readonly ReactiveProperty<HeroRemoteDataModel> HeroRemoteModel;
        public readonly ReactiveDictionary<long, AnimalRemoteDataModel> AnimalRemoteDatas;

        public RemoteDataModel()
        {
            Coins = new ReactiveProperty<double>(0.0);
            HeroRemoteModel = new ReactiveProperty<HeroRemoteDataModel>();
            AnimalRemoteDatas = new ReactiveDictionary<long, AnimalRemoteDataModel>();
        }

        public void SeedUserData(UserData userData)
        {
            UserData = userData;

            foreach (var animal in userData.AnimalsStates)
            {
                AddAnimalRemoteData(animal);
            }

            // Seeding the Meta to GameState Instances.
            userData.HeroState.FarmEntityData = _staticDataModel.MetaData.HeroLevels[userData.HeroState.HeroLevel - 1];
            
            // Creating Models respecting to GameStateEntries.
            HeroRemoteModel.Value = _heroFactory.Create();
            
            // Seeding the GameStateData to the in-memory Model.
            HeroRemoteModel.Value.SeedHeroRemoteData(userData.HeroState, this);

            Coins.Value = userData.Coins;
        }

        public void AddAnimalRemoteData(AnimalRemoteData animal)
        {
            // Seeding the Meta to GameState Instances.
            animal.FarmEntityData =
                _staticDataModel.MetaData.Animals.First(a => a.AnimalType.Equals(animal.AnimalType));
            
            // Creating Models respecting to GameStateEntries.
            var tmp = _animalFactory.Create();
                
            // Seeding the GameStateData to the in-memory Model.
            tmp.SeedAnimalRemoteData(animal);
                
            // Adding it to the Animals List.
            AnimalRemoteDatas.Add(animal.Id, tmp);
        }

        public HeroRemoteDataModel HeroModel
        {
            get { return HeroRemoteModel.Value; }
        }

        public void UpdateCoins(double coins)
        {
            UserData.Coins = coins;
            Coins.Value = coins;
        }
    }
}

