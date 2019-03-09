using UnityEngine;

namespace game.core.view
{
    public interface IPopupButtonData
    {
        Sprite Sprite { get; set; }
        string Text { get; set; }
    }
}