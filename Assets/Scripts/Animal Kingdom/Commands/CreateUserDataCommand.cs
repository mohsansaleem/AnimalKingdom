using Zenject;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;
using PG.animalKingdom.installer;
using PG.animalKingdom.model.scene;
using PG.animalKingdom.view;
using PG.Core.Commands;

namespace PG.animalKingdom.command
{
    public class CreateUserDataCommand : BaseCommand
    {
        [Inject] private readonly BootstrapModel _bootstrapModel;

        public void Execute(CreateUserDataSignal commandParams)
        {
            try
            {
                // TODO: MS: Encrypt the Data. For now saving plain to read and change.
                string path = Path.Combine(Application.streamingAssetsPath, Constants.GameStateFile);

                StreamWriter writer = new StreamWriter(path);
                writer.Write(JsonConvert.SerializeObject(commandParams.UserData, Formatting.Indented));
                writer.Flush();
                writer.Close();

                commandParams.OnUserCreated.Resolve();
            }
            catch(Exception ex)
            {
                Debug.LogError("Exception");
                commandParams.OnUserCreated.Reject(ex);
            }
        }
    }
}
