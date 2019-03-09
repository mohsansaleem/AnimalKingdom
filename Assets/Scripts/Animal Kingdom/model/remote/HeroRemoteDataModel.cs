using System;
using game.animalKingdom.model.data;
using UniRx;
using Zenject;

namespace game.animalKingdom.model.remote
{
    public class HeroRemoteDataModel : EntityRemoteDataModel
    {
        [Inject] private readonly StaticDataModel _staticDataModel;

        private CompositeDisposable _disposables;

        public readonly ReactiveProperty<HeroRemoteData> HeroRemoteData;
        public readonly ReactiveProperty<float> SpeedBoost;
        public readonly ReactiveProperty<TimeSpan> RemainingTime;
        public readonly ReactiveCollection<EntityRemoteDataModel> Group;
        public DateTime SpeedLastUpdate;


        public HeroRemoteDataModel()
        {
            HeroRemoteData = new ReactiveProperty<HeroRemoteData>();
            SpeedBoost = new ReactiveProperty<float>();
            RemainingTime = new ReactiveProperty<TimeSpan>();
            Group = new ReactiveCollection<EntityRemoteDataModel>();
            SpeedLastUpdate = new DateTime();

            _disposables = new CompositeDisposable();
        }

        public override float Speed => RemoteData.Speed + SpeedBoost.Value;
        public override float PatrolSpeed => Speed;
        public HeroData Data => HeroRemoteData.Value.HeroData;
        public HeroRemoteData RemoteData => HeroRemoteData.Value;

        public void SeedHeroRemoteData(HeroRemoteData heroRemoteData, RemoteDataModel _remoteDataModel)
        {
            HeroRemoteData.Value = heroRemoteData;
            SpeedBoost.Value = 0;
            RemainingTime.Value = TimeSpan.FromSeconds(_staticDataModel.MetaData.GameTime);
            SpeedLastUpdate = DateTime.Now;

            if (heroRemoteData.AnimalsInGroup != null)
            {
                foreach (var id in heroRemoteData.AnimalsInGroup)
                {
                    Group.Add(_remoteDataModel.AnimalRemoteDatas[id]);
                }
            }
        }

        public void ResetGameTime()
        {
            RemainingTime.Value = TimeSpan.FromSeconds(_staticDataModel.MetaData.GameTime);
        }
        
        public void TimeTick()
        {
            RemainingTime.SetValueAndForceNotify(RemainingTime.Value - TimeSpan.FromSeconds(1));
        }

        public void AddAnimalToGroup(EntityRemoteDataModel model)
        {
            if (!Group.Contains(model))
            {
                Group.Add(model);
            }
        }

        public void RemoveAnimalFromGroup(EntityRemoteDataModel model)
        {
            Group.Remove(model);
        }

        public class Factory : PlaceholderFactory<HeroRemoteDataModel>
        {
        }
    }
}