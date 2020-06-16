using System;
using System.Linq;
using PG.AnimalKingdom.Contexts.Popup.data;
using PG.AnimalKingdom.Installer;
using PG.AnimalKingdom.Views.Popup;
using PG.Core.Context;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Contexts.Popup.sub
{
    public class PopupDialogFacade : MonoBehaviour, IPoolable<PopupData, IMemoryPool>, IDisposable
    {
        [Inject] private PopupDialogView _view;
        [Inject] private PopupDialogRegistry _registry;
        [Inject] private PopupButtonFacade.Factory _popupButtonFactory;
        [Inject] private PopupButtonRegistry _popupButtonRegistry;
        [Inject] private ProjectContextInstaller.Settings _settings;

        private PopupData _popupData;
        private IMemoryPool _pool;

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        public void OnDespawned()
        {
            var buttons = _popupButtonRegistry.PopupButtons.Keys.ToList();
            buttons.ForEach( btn => _popupButtonRegistry.DisposeEntry(btn));

            _registry.RemovePopupDialog(_popupData);
            _pool = null;
        }

        public void OnSpawned(PopupData popupData, IMemoryPool pool)
        {
            _pool = pool;

            _popupData = popupData;

            _view.transform.localScale = Vector3.one;
            _view.SetData(popupData);

            foreach (IPopupButtonData popupButtonData in popupData.PopupConfig.ButtonData)
            {
                _popupButtonFactory.Create((PopupButtonData)popupButtonData, popupData);
            }

            _registry.AddPopupDialog(popupData, this);
        }

        public class Factory : PlaceholderFactory<PopupData, PopupDialogFacade>
        {
        }
    }
}

