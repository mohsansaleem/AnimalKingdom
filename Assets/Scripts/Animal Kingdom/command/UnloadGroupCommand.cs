using Zenject;
using UnityEngine;
using System;
using game.animalKingdom.installer;
using game.animalKingdom.model.remote;
using game.animalKingdom.model.scene;
using game.core.command;
using UniRx;

namespace game.animalKingdom.command
{
    public class UnloadGroupCommand : BaseCommand
    {
        [Inject] private RemoteDataModel _remoteDataModel;
        [Inject] private GamePlayModel _gamePlayModel;

        public void Execute(UnloadGroupSignal param)
        {
            try
            {
                var hero = _remoteDataModel.HeroModel;
                
                AnimalRemoteDataModel model;
                foreach (var animal in hero.Group)
                {
                    model = (AnimalRemoteDataModel) animal;
                    
                    _remoteDataModel.Coins.Value += model.Data.PenPoints;
                    
                    _remoteDataModel.AnimalRemoteDatas.Remove(model.RemoteData.Id);
                }

                hero.Group.Clear();
                hero.RemoteData.AnimalsInGroup.Clear();
                
                // Adding the 1 second delay as it was asked.
                Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe( (t) => _gamePlayModel.GamePlayState.Value = 
                    GamePlayModel.EGamePlayState.Gathering );
            }
            catch(Exception ex)
            {
                Debug.LogError("Error while Saving User: "+ ex.ToString());
            }
        }
    }

}
