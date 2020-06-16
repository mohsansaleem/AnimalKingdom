using System;
using PG.AnimalKingdom.Contexts.Popup.data;
using PG.AnimalKingdom.Generic.UI;
using PG.AnimalKingdom.Installer;
using PG.Core.Context;
using UnityEngine;
using Zenject;

namespace PG.AnimalKingdom.Contexts.Popup.sub
{
    public class PopupButtonFacade : MonoBehaviour, IPoolable<PopupButtonData, PopupData, IMemoryPool>, IDisposable
    {
        // No need to Inject if we are not using Installer or Method to Install.
        // Component in the Prefab would just do.
        [Header("References")]
        public UIButton _view;

        // Injection stuff from parent/upper containers.
        [Inject] private PopupButtonRegistry _registry;
        [Inject] private PopupDialogRegistry _popupDialogRegistry;
        [Inject] private ProjectContextInstaller.Settings _settings;

        private PopupButtonData _popupButtonData;
        private PopupData _popupData;
        private IMemoryPool _pool;

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        public void OnDespawned()
        {
            _view.RemoveAllListeners();
            _registry.RemovePopupButton(_popupButtonData);
            _pool = null;
        }

        public void OnSpawned(PopupButtonData popupButtonData, PopupData popupData, IMemoryPool pool)
        {
            _pool = pool;

            _popupData = popupData;
            _popupButtonData = popupButtonData;

            // View Data.
            _view.Data = popupButtonData;
            _view.SetLabel(popupButtonData.Text);
            _view.AddListener((button)=> { OnPopupButtonClicked(_popupData, _popupButtonData);});
            
            _registry.AddPopupButton(popupButtonData, this);
        }

        private void OnPopupButtonClicked(PopupData popupData, PopupButtonData popupButtonData)
        {
            if (popupData.PopupConfig.ButtonData.Contains(popupButtonData))
            {
                IPopupResult popupResult = popupData.PopupConfig.GetPopupResult();

                popupResult.SelectedIndex = popupData.PopupConfig.ButtonData.IndexOf(popupButtonData);

                popupData.OnPopupComplete.Resolve(popupResult);

                // TODO: MS: Add the Bool for CloseOnClick for Buttons.

                // Destroying/Desposing the PopupDialog as its work is done on click.
                _popupDialogRegistry.GetPopupDialog(popupData).Dispose();
            }
            else
            {
                throw new Exception("PopupMediator.OnPopupButtonClicked: Something went wrong.");
            }

        }

        public class Factory : PlaceholderFactory<PopupButtonData, PopupData, PopupButtonFacade>
        {
        }
    }
}

