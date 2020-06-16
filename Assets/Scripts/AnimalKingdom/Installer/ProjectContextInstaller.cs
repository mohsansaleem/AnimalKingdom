using System;
using System.Collections.Generic;
using PG.AnimalKingdom.Contexts.Bootstrap.DefaultData;
using PG.AnimalKingdom.Models;
using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Models.Data;
using PG.AnimalKingdom.Models.Remote;
using PG.AnimalKingdom.Views.GamePlay;
using PG.Core.installer;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Installer
{
    public class ProjectContextInstaller : CoreContextInstaller
    {
        [Inject] private Settings _settings;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.Bind<PopupSystemDataModel>().AsSingle();
            Container.Bind<StaticDataModel>().AsSingle();
            Container.Bind<RemoteDataModel>().AsSingle();
            Container.Bind<BootstrapModel>().AsSingle();
            Container.Bind<GamePlayModel>().AsSingle();
            
            Container.BindFactory<HeroRemoteDataModel, HeroRemoteDataModel.Factory>();
            Container.BindFactory<AnimalRemoteDataModel, AnimalRemoteDataModel.Factory>();
            
        }

        [Serializable]
        public class Settings
        {
            // Meta Stuff
            public DefaultGameState DefaultGameState;
            
            /// <summary>
            /// Just doing it for the ease of creating MetaData from Scriptable object.
            /// </summary>
            public DefaultMetaData MetaDataAsset;
            
            // Popup Prefabs
            public GameObject PopupDialogPrefab;
            public GameObject PopupButtonPrefab;

            // GamePlay Prefabs
            public HeroView HeroPrefab;
            
            public List<AnimalPrefab> AnimalsPrefabs;
        }   
    }
    
    [Serializable]
    public class AnimalPrefab
    {
        public EAnimalType Type;
        public GameObject Prefab;

        public override string ToString()
        {
            return Type.ToString()+"s";
        }
    }
}