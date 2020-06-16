using System;
using PG.AnimalKingdom.Contexts.GamePlay;
using PG.AnimalKingdom.Models;
using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Models.Data;
using PG.AnimalKingdom.Models.Remote;
using PG.Core.Commands;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Commands
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
