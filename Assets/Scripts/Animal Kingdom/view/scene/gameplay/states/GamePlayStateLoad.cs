using game.animalKingdom.model.scene;
using RSG;
using Sirenix.Utilities;

namespace game.animalKingdom.view
{
    public partial class GamePlayMediator
    {
        public class GamePlayStateLoad : GamePlayState
        {
            public GamePlayStateLoad(GamePlayMediator mediator) : base(mediator)
            {
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();
                
                // Spawning Animals
                SpawnAnimals().Done(((v) =>
                {
                    Mediator._gamePlayModel.GamePlayState.SetValueAndForceNotify(GamePlayModel.EGamePlayState.Gathering);
                }));
            }

            private IPromise<AnimalView> SpawnAnimals()
            {
                Promise<AnimalView> promise = null;

                RemoteDataModel.AnimalRemoteDatas.ForEach((animalData) =>
                {
                    if (promise == null)
                    {
                        promise = (Promise<AnimalView>) Mediator.SpawnAnimal(animalData.Value);
                    }
                    else
                    {
                        promise = (Promise<AnimalView>)promise.Then((v) => Mediator.SpawnAnimal(animalData.Value));
                    }
                });

                return promise;
            }

            
        }
    }
}