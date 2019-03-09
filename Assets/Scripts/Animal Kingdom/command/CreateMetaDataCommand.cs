using Zenject;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;
using game.animalKingdom.installer;
using game.animalKingdom.model.scene;
using game.animalKingdom.view;
using game.core.command;

namespace game.animalKingdom.command
{
    public class CreateMetaDataCommand : BaseCommand
    {
        [Inject] private readonly BootstrapModel _bootstrapModel;

        public void Execute(CreateMetaDataSignal commandParams)
        {
            try
            {
                // TODO: MS: Encrypt the Data. For now saving plain to read and change.
                string path = Path.Combine(Application.streamingAssetsPath, Constants.MetaDataFile);

                StreamWriter writer = new StreamWriter(path);
                writer.Write(JsonConvert.SerializeObject(commandParams.MetaData, Formatting.Indented));
                writer.Flush();
                writer.Close();

                commandParams.OnMetaCreated.Resolve();
            }
            catch(Exception ex)
            {
                commandParams.OnMetaCreated.Reject(ex);
            }
        }
    }
}
