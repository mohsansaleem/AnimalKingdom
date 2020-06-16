using Zenject;
using UnityEngine;
using System;
using PG.animalKingdom.installer;
using PG.animalKingdom.model;
using PG.animalKingdom.model.remote;
using PG.animalKingdom.model.scene;
using PG.Core.Commands;

namespace PG.animalKingdom.command
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
