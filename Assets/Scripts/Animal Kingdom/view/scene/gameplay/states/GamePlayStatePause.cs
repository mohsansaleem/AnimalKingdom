using game.animalKingdom.view.popup.popupconfig;
using game.animalKingdom.view.popup.popupresult;
using UnityEngine;

namespace game.animalKingdom.view
{
    public partial class GamePlayMediator
    {
        public class GamePlayStatePause : GamePlayState
        {
            public GamePlayStatePause(GamePlayMediator mediator) : base(mediator)
            {
                
            }

            public override void OnStateEnter()
            {
                base.OnStateEnter();

                Mediator.ShowPopup(MessagePopupConfig.GetMessagePopupConfig
                        ("Time Over", "Your Time is over"))
                    .Done((result) =>
                    {
                        MessagePopupResult popupResult = (MessagePopupResult)result;
                        if (popupResult.Ok)
                        {
                            Mediator.OnBackButtonClicked();
                            UnityEngine.Debug.Log("Ok Button Clicked.");
                            // Success.
                        }
                    }, Debug.LogError);
                
                Time.timeScale = 0f;
            }

            public override void OnStateExit()
            {
                base.OnStateExit();

                Time.timeScale = 1f;
            }
        }
    }
}