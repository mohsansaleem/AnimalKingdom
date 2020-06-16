using Zenject;
using UnityEngine;
using System;
using PG.animalKingdom.installer;
using PG.animalKingdom.model;
using PG.animalKingdom.model.data;
using PG.animalKingdom.model.remote;
using PG.animalKingdom.model.scene;
using PG.Core.Commands;

namespace PG.animalKingdom.command
{
    public class SpawnIfSpaceCommand : BaseCommand
    {
        [Inject] private RemoteDataModel _remoteDataModel;
        [Inject] private StaticDataModel _staticDataModel;
        [Inject] private GamePlayModel _gamePlayModel;

        public void Execute(SpawnIfSpaceSignal param)
        {
            try
            {
                if (_remoteDataModel.AnimalRemoteDatas.Count - _remoteDataModel.HeroModel.Group.Count <
                    _staticDataModel.MetaData.FarmSpace)
                {
                    _remoteDataModel.AddAnimalRemoteData(AnimalRemoteData.GetRandom);
                }
            }
            catch(Exception ex)
            {
                Debug.LogError("Error while Saving User: "+ ex.ToString());
            }
        }
    }

}
