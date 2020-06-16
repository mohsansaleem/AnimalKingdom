using System;
using PG.AnimalKingdom.Contexts.GamePlay;
using PG.AnimalKingdom.Models;
using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Models.Remote;
using PG.Core.Commands;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Commands
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
