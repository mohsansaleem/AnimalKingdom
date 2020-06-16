using System;
using PG.Core.Context;
using UnityEngine;


namespace PG.animalKingdom.view.popup
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