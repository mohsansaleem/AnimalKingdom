﻿using System.Collections.Generic;
using PG.AnimalKingdom.Contexts.Popup.data;

namespace PG.AnimalKingdom.Contexts.Popup.sub
{
    public class PopupButtonRegistry
    {
        readonly Dictionary<PopupButtonData, PopupButtonFacade> _popupButtons = new Dictionary<PopupButtonData, PopupButtonFacade>();

        public Dictionary<PopupButtonData, PopupButtonFacade> PopupButtons => _popupButtons;

        public void AddPopupButton(PopupButtonData popupButtonData, PopupButtonFacade popupButton)
        {
            _popupButtons.Add(popupButtonData, popupButton);
        }

        public void RemovePopupButton(PopupButtonData popupButtonData)
        {
            _popupButtons.Remove(popupButtonData);
        }

        public PopupButtonFacade GetPopupButton(PopupButtonData popupButtonData)
        {
            return _popupButtons[popupButtonData];
        }

        public void DisposeEntry(PopupButtonData popupButtonData)
        {
            _popupButtons[popupButtonData].Dispose();
        }
    }
}

