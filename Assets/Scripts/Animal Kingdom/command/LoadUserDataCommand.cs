using Zenject;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;
using game.animalKingdom.installer;
using game.animalKingdom.model.data;
using game.animalKingdom.model.remote;
using game.animalKingdom.model.scene;
using game.animalKingdom.view;
using game.core.command;

namespace game.animalKingdom.command
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
