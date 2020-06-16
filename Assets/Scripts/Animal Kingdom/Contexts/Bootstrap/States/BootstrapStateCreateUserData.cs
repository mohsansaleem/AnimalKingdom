using PG.animalKingdom.installer;
using PG.animalKingdom.model.data;
using PG.animalKingdom.model.remote;
using PG.animalKingdom.model.scene;
using UnityEngine;

namespace PG.animalKingdom.view
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateCreateUserData : BootstrapState
        {
            private readonly RemoteDataModel _remoteDataModel;

            public BootstrapStateCreateUserData(BootstrapMediator mediator) : base(mediator)
            {
                _remoteDataModel = mediator._remoteDataModel;
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();

                UserData userData = GameSettings.DefaultGameState.User;

                CreateUserDataSignal.CreateUserData(SignalBus, userData).Then(
                    () => {
                        _remoteDataModel.SeedUserData(userData);
                        BootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.DataSeeded;
                    }
                ).Catch(e =>
                {
                    Debug.LogError("Exception Creating new User: " + e.ToString());
                });
            }
        }
    }
}