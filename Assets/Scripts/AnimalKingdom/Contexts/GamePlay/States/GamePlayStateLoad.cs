using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Views.GamePlay;
using RSG;

namespace PG.AnimalKingdom.Contexts.GamePlay
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

                foreach (var animalRemoteDataModel in RemoteDataModel.AnimalRemoteDatas)
                {
                    if (promise == null)
                    {
                        promise = (Promise<AnimalView>) Mediator.SpawnAnimal(animalRemoteDataModel.Value);
                    }
                    else
                    {
                        promise = (Promise<AnimalView>)promise.Then<AnimalView>((v) => 
                            Mediator.SpawnAnimal(animalRemoteDataModel.Value));
                    }
                }

                return promise;
            }

            
        }
    }
}