using System;
using System.IO;
using Newtonsoft.Json;
using PG.AnimalKingdom.Contexts.Bootstrap;
using PG.AnimalKingdom.Generic;
using PG.AnimalKingdom.Models.Remote;
using PG.Core.Commands;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Commands
{
    public class SaveUserDataCommand : BaseCommand
    {
        [Inject] private RemoteDataModel _remoteDataModel;

        public void Execute(SaveUserDataSignal param)
        {
            try
            {
                // TODO: MS: Encrypt the Data. For now saving plain to read and change.
                string path = Path.Combine(Application.streamingAssetsPath, Constants.GameStateFile);
                
                StreamWriter writer = new StreamWriter(path);
                writer.Write(JsonConvert.SerializeObject(_remoteDataModel.UserData, Formatting.Indented));
                writer.Flush();

                writer.Close();
            }
            catch(Exception ex)
            {
                Debug.LogError("Error while Saving User: "+ ex.ToString());
            }
        }
    }

}
