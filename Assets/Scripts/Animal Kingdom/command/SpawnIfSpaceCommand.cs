using Zenject;
using UnityEngine;
using System;
using game.animalKingdom.installer;
using game.animalKingdom.model;
using game.animalKingdom.model.data;
using game.animalKingdom.model.remote;
using game.animalKingdom.model.scene;
using game.core.command;

namespace game.animalKingdom.command
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
