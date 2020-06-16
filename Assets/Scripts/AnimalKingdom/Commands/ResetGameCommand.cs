using System;
using PG.AnimalKingdom.Contexts.GamePlay;
using PG.AnimalKingdom.Models.Remote;
using PG.Core.Commands;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Commands
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
