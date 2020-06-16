using PG.AnimalKingdom.Contexts.Popup.popupconfig;
using PG.AnimalKingdom.Contexts.Popup.PopupResult;
using PG.AnimalKingdom.Models.Context;
using PG.Core.installer;
using UnityEngine;

namespace PG.AnimalKingdom.Contexts.Bootstrap
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateLoadPopup : BootstrapState
        {
            public BootstrapStateLoadPopup(Bootstrap.BootstrapMediator mediator) : base(mediator)
            {
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();
                
                LoadUnloadScenesSignal.Load(SignalBus, Scenes.Popup).Done
                (
                    () =>
                    {
                        // Testing Popup
                    #if UNITY_EDITOR && DEBUG
                        //ShowYesNoPopup();            
                    #endif
                        
                        BootstrapModel.LoadingProgress.Value = BootstrapModel.ELoadingProgress.LoadStaticData;
                    },
                exception =>
                {
                    UnityEngine.Debug.LogError(exception);
                }
                );
            }

            #if UNITY_EDITOR && DEBUG
            private void ShowYesNoPopup()
            {
                Mediator.ShowPopup(YesNoPopupConfig.GetYesNoPopupConfig
                        ("Start Game?", "Going to Start Game"))
                    .Done((result) =>
                    {
                        YesNoPopupResult popupResult = (YesNoPopupResult)result;
                        if (popupResult.Yes)
                        {
                            UnityEngine.Debug.Log("Yes Button Clicked.");
                            // Success.
                        }
                        else if (popupResult.No)
                        {
                            UnityEngine.Debug.LogError("No Button Clicked.");
                            ShowYesNoPopup();
                        }
                    }, Debug.LogError);
            }
            #endif
        }
    }
}