using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Models.Data;
using PG.AnimalKingdom.Models.Remote;
using UnityEngine;

namespace PG.AnimalKingdom.Contexts.Bootstrap
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateCreateUserData : BootstrapState
        {
            private readonly RemoteDataModel _remoteDataModel;

            public BootstrapStateCreateUserData(Bootstrap.BootstrapMediator mediator) : base(mediator)
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