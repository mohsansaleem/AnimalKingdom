using PG.animalKingdom.model.scene;
using RSG;

namespace PG.animalKingdom.view
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
                    Mediator._gamePlayModel.GamePlayState.SetValueAndForceNotify(model.scene.GamePlayModel.EGamePlayState.Gathering);
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
                        promise = (Promise<AnimalView>)promise.Then((v) => 
                            Mediator.SpawnAnimal(animalRemoteDataModel.Value));
                    }
                }

                return promise;
            }

            
        }
    }
}