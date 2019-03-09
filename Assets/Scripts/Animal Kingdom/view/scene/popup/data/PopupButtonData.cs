using System;
using game.core.view;
using UnityEngine;


namespace game.animalKingdom.view.popup
{
    [Serializable]
    public class PopupButtonData : IPopupButtonData
    {
        public PopupButtonData(string text)
        {
            Text = text;
        }

        public Sprite Sprite { get; set; }
        public string Text { get; set; }
    }
}