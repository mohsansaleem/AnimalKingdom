using Zenject;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;
using PG.animalKingdom.installer;
using PG.animalKingdom.model.remote;
using PG.animalKingdom.view;
using PG.Core.Commands;

namespace PG.animalKingdom.command
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
