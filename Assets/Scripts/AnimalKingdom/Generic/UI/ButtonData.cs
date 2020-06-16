﻿using System;
using UnityEngine;

namespace PG.AnimalKingdom.Generic.UI
{
    [Serializable]
    public class ButtonData
    {
        public Sprite Sprite;
        public string Text;
        public Action OnSelected;

        public ButtonData(Sprite sprite, string text, Action onSelected)
        {
            Sprite = sprite;
            Text = text;
            OnSelected = onSelected;
        }
    }
}