using Zenject;
using UnityEngine;
using System;
using game.animalKingdom.installer;
using game.animalKingdom.model;
using game.animalKingdom.model.remote;
using game.animalKingdom.model.scene;
using game.core.command;

namespace game.animalKingdom.command
{
    public class AddAnimalToGroupCommand : BaseCommand
    {
        [Inject] private RemoteDataModel _remoteDataModel;
        [Inject] private StaticDataModel _staticDataModel;
        [Inject] private GamePlayModel _gamePlayModel;

        public void Execute(AddAnimalToGroupSignal param)
        {
            try
            {
                if (_remoteDataModel.HeroModel.Group.Count < _staticDataModel.MetaData.HeroSpace)
                {
                    _remoteDataModel.HeroModel.AddAnimalToGroup(param.AnimalModel);
                    
                    param.OnAnimalAdded.Resolve();
                }
                else
                {
                    param.OnAnimalAdded.Reject(new Exception("No more Space."));
                }
            }
            catch(Exception ex)
            {
                Debug.LogError("Error while Saving User: "+ ex.ToString());
            }
        }
    }

}
