using System.Collections.Generic;
using PG.animalKingdom.installer;
using PG.AnimalKingdom.Installer;
using PG.animalKingdom.model.remote;
using PG.animalKingdom.model.scene;
using PG.Core;
using PG.Core.Context;

namespace PG.animalKingdom.view
{
    public partial class GamePlayMediator
    {
        public class GamePlayState : StateBehaviour
        {
            protected readonly GamePlayMediator Mediator;
            
            protected readonly GamePlayModel GamePlayModel;
            protected readonly GamePlayView View;

            protected readonly ProjectContextInstaller.Settings ProjectSettings;

            protected readonly RemoteDataModel RemoteDataModel;
            protected readonly Dictionary<long, AnimalView> Animals;
            
            public GamePlayState(GamePlayMediator mediator)
            {
                this.Mediator = mediator;
                
                this.GamePlayModel = mediator._gamePlayModel;
                this.View = mediator._view;

                this.ProjectSettings = mediator._projectSettings;

                this.RemoteDataModel = mediator._remoteDataModel;
                this.Animals = mediator._animalViews;
            }
        }
    }
}
