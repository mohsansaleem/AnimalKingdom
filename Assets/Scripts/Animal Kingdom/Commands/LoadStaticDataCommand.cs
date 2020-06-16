using Newtonsoft.Json;
using System;
using UnityEngine;
using RSG;
using Zenject;
using System.IO;
using PG.animalKingdom.installer;
using PG.animalKingdom.model;
using PG.animalKingdom.model.data;
using PG.animalKingdom.view;
using PG.Core.Commands;

namespace PG.animalKingdom.command
{
    public class LoadStaticDataCommand : BaseCommand
    {
        [Inject] private readonly StaticDataModel _staticDataModel;

        public void Execute(LoadStaticDataSignal loadParam)
        {
            var sequence = Promise.Sequence(
                () => LoadMetaJson(Constants.MetaDataFile)
                // Add other Jsons or asset bundles etc.
            );

            sequence
                .Then(() =>
                    {
                        Debug.Log(string.Format("{0} , static data load completed!", this));
                        loadParam.DataLoadPromise.Resolve();
                    }
                )
                .Catch(e =>
                    {
                        Debug.LogError("MetaData doesn't Exist. Creating from Scriptable Object.");
                        loadParam.DataLoadPromise.Reject(e);
                    }
                );
        }

        // For now just loading everything from StreamingAssets. Proper way would be loading it from AssetBudles.
        private IPromise LoadMetaJson(string metaFileName)
        {
            Promise promiseReturn = new Promise();

            try
            {
                // TODO: MS: Encrypt the Data. For now saving plain to read and change.
                string path = Path.Combine(Application.streamingAssetsPath, metaFileName);
                
                StreamReader reader = new StreamReader(path);
                MetaData metaData = JsonConvert.DeserializeObject<MetaData>(reader.ReadToEnd());
                reader.Close();

                _staticDataModel.SeedMetaData(metaData);

                promiseReturn.Resolve();
            }
            catch(Exception ex)
            {
                promiseReturn.Reject(ex);
            }

            return promiseReturn;
        }
    }
}