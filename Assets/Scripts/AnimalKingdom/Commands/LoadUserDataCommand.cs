using System;
using System.IO;
using Newtonsoft.Json;
using PG.AnimalKingdom.Contexts.Bootstrap;
using PG.AnimalKingdom.Generic;
using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Models.Data;
using PG.AnimalKingdom.Models.Remote;
using PG.Core.Commands;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Commands
{
    public class LoadUserDataCommand : BaseCommand
    {
        [Inject] private RemoteDataModel _remoteDataModel;
        [Inject] private readonly BootstrapModel _bootstrapModel;

        public void Execute(LoadUserDataSignal loadParam)
        {
            try
            {
                // TODO: MS: Encrypt the Data. For now saving plain to read and change.
                string path = Path.Combine(Application.streamingAssetsPath, Constants.GameStateFile);

                if (File.Exists(path))
                {
                    StreamReader reader = new StreamReader(path);
                    UserData userData = JsonConvert.DeserializeObject<UserData>(reader.ReadToEnd());
                    reader.Close();

                    _remoteDataModel.SeedUserData(userData);

                    Debug.Log("UserData Loaded From: " + path);

                    loadParam.DataLoadPromise.Resolve();
                }
                else
                    loadParam.DataLoadPromise.Reject(new FileNotFoundException(Constants.GameStateFile + " doesn't Exist."));

            }
            catch (Exception ex)
            {
                loadParam.DataLoadPromise.Reject(ex);
            }
        }
    }

}
