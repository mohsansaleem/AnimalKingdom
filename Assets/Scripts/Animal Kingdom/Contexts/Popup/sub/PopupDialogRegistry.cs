﻿using System.Collections.Generic;

namespace PG.animalKingdom.view.popup
{
    public class PopupDialogRegistry
    {
        readonly Dictionary<PopupData, PopupDialogFacade> _popupDialogs = new Dictionary<PopupData, PopupDialogFacade>();

        public Dictionary<PopupData, PopupDialogFacade> PopupDialogs => _popupDialogs;

        public void AddPopupDialog(PopupData popupData, PopupDialogFacade popupDialog)
        {
            _popupDialogs.Add(popupData, popupDialog);
        }

        public void RemovePopupDialog(PopupData popupData)
        {
            _popupDialogs.Remove(popupData);
        }

        public PopupDialogFacade GetPopupDialog(PopupData popupData)
        {
            return _popupDialogs[popupData];
        }

        public void DisposeEntry(PopupData popupData)
        {
            _popupDialogs[popupData].Dispose();
        }
    }
}

