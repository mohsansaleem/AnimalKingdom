using game.animalKingdom.installer;
using game.animalKingdom.model;
using game.animalKingdom.model.data;
using game.animalKingdom.model.scene;
using UnityEngine;

namespace game.animalKingdom.view
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateCreateMetaData : BootstrapState
        {
            private readonly StaticDataModel _staticDataModel;

            public BootstrapStateCreateMetaData(BootstrapMediator mediator) : base(mediator)
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