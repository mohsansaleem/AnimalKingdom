using UnityEngine;

namespace PG.Core.Context
{
    public interface IPopupButtonData
    {
        Sprite Sprite { get; set; }
        string Text { get; set; }
    }
}