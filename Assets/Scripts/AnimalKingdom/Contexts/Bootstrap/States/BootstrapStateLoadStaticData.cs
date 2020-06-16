﻿using PG.AnimalKingdom.Models.Context;

namespace PG.AnimalKingdom.Contexts.Bootstrap
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateLoadStaticData : BootstrapState
        {
            public BootstrapStateLoadStaticData(Bootstrap.BootstrapMediator mediator) : base(mediator)
            {
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();

                View.Show();
                
                LoadStaticDataSignal.LoadStaticData(SignalBus).Then(
                    () =>
                    {
                        BootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.StaticDataLoaded;
                    }
                ).Catch(e =>
                {
                    BootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.MetaNotFound;
                });
            }
        }
    }
}