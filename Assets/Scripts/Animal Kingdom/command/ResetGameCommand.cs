using Zenject;
using UnityEngine;
using System;
using game.animalKingdom.installer;
using game.animalKingdom.model.remote;
using game.core.command;

namespace game.animalKingdom.command
{
    public class ResetGameCommand : BaseCommand
    {
        [Inject] private RemoteDataModel _remoteDataModel;

        public void Execute(ResetGameSignal param)
        {
            try
            {
                // Resetting GameTimer.
                _remoteDataModel.HeroModel.ResetGameTime();
                
                // Reset Last Speed Update Time.
                _remoteDataModel.HeroModel.SpeedLastUpdate = DateTime.Now;
            }
            catch(Exception ex)
            {
                Debug.LogError("Error while Resetting: "+ ex.ToString());
            }
        }
    }

}
