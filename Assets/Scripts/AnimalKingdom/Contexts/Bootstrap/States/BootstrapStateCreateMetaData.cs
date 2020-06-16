using PG.AnimalKingdom.Models;
using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Models.Data;
using UnityEngine;

namespace PG.AnimalKingdom.Contexts.Bootstrap
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateCreateMetaData : BootstrapState
        {
            private readonly StaticDataModel _staticDataModel;

            public BootstrapStateCreateMetaData(Bootstrap.BootstrapMediator mediator) : base(mediator)
            {
                _staticDataModel = mediator._staticDataModel;
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();
                
                MetaData MetaData = GameSettings.MetaDataAsset.Meta;

                CreateMetaDataSignal.CreateMetaData(SignalBus, MetaData).Then(
                    () => {
                        _staticDataModel.SeedMetaData(MetaData);
                        BootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.StaticDataLoaded;
                    }
                ).Catch(e =>
                {
                    Debug.LogError("Exception Creating new Meta: " + e.ToString());
                });
            }
        }
    }
}