using game.animalKingdom.view.popup.popupconfig;
using game.animalKingdom.view.popup.popupresult;
using game.animalKingdom.view.scene;
using game.core.installer;
using UnityEngine;

namespace game.animalKingdom.view
{
    public partial class BootstrapMediator
    {
        public class BootstrapStateLoadPopup : BootstrapState
        {
            public BootstrapStateLoadPopup(BootstrapMediator mediator) : base(mediator)
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
                        
                        BootstrapModel.LoadingProgress.Value = model.scene.BootstrapModel.ELoadingProgress.PopupLoaded;
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