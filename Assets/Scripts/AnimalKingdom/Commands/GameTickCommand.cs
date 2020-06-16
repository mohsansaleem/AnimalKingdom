using System;
using PG.AnimalKingdom.Contexts.GamePlay;
using PG.AnimalKingdom.Models.Context;
using PG.AnimalKingdom.Models.Remote;
using PG.Core.Commands;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Commands
{
    public class GameTickCommand : BaseCommand
    {
        [Inject] private RemoteDataModel _remoteDataModel;
        [Inject] private GamePlayModel _gamePlayModel;

        public void Execute(GameTickSignal param)
        {
            try
            {
                var hero = _remoteDataModel.HeroModel;
                // Update the Remaing Time.
                hero.TimeTick();

                // Check the End Game Condition.
                if (hero.RemainingTime.Value.TotalSeconds < 1)
                {
                    _gamePlayModel.GamePlayState.Value = GamePlayModel.EGamePlayState.Pause;
                }

                // Update the Hero Speed.
                if ((DateTime.Now - hero.SpeedLastUpdate).TotalSeconds >= hero.Data.SpeedJumpInterval)
                {
                    float newSpeed = hero.SpeedBoost.Value + hero.Data.SpeedJump;
                    if (newSpeed <= hero.Data.MaxSpeed)
                    {
                        hero.SpeedLastUpdate = DateTime.Now;
                        hero.SpeedBoost.Value = newSpeed;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Error while Timer Tick: " + ex.ToString());
            }
        }
    }
}