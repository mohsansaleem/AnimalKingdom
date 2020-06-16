using System;
using System.IO;
using Newtonsoft.Json;
using PG.AnimalKingdom.Contexts.Bootstrap;
using PG.AnimalKingdom.Generic;
using PG.AnimalKingdom.Models.Context;
using PG.Core.Commands;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Commands
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
