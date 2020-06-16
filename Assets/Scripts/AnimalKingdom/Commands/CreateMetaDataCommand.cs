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
