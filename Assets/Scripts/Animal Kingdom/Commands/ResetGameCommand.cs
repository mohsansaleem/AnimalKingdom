using Zenject;
using UnityEngine;
using System;
using PG.animalKingdom.installer;
using PG.animalKingdom.model.remote;
using PG.Core.Commands;

namespace PG.animalKingdom.command
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
