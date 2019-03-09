using System;
using RSG;
using UnityEngine;
using Zenject;

namespace game.core.view
{
    public class OpenPopupSignal
    {
        public IPopupConfig PopupConfig;
        public Promise<IPopupResult> OnPopupComplete;

        public static Promise<IPopupResult> ShowPopup(SignalBus signalBus, IPopupConfig popupConfig)
        {
            try
            {
                OpenPopupSignal openPopupParams = new OpenPopupSignal
                {
                    OnPopupComplete = new Promise<IPopupResult>(),
                    PopupConfig = popupConfig
                };

                signalBus.TryFire(openPopupParams);

                return openPopupParams.OnPopupComplete;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }
    }
}