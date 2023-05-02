using System.Collections.Generic;
using System.Linq;
using Infrastructure.MonoComponents.UI.UIRoot;
using Infrastructure.MonoComponents.UI.UIRoot.Data;
using Infrastructure.Services.PopupService.Container;
using Infrastructure.Services.PopupService.Data;
using UnityEngine;

namespace Infrastructure.Services.PopupService.Implementation
{
    public class PopupService : IPopupService
    {
        public bool HasAnyPopupsOpened => _openedPopups.Count > 0;

        public PopupService(IPopupContainer popupContainer, IUIRoot uiRoot)
        {
            _popupContainer = popupContainer;
            _uiRoot = uiRoot;
            _openedPopups = new List<PopupConfiguration>(4);
            _popupQueue = new Queue<PopupConfiguration>(4);
        }
        
        private readonly IPopupContainer _popupContainer = null;
        private readonly IUIRoot _uiRoot = null;
        private List<PopupConfiguration> _openedPopups = null;
        private Queue<PopupConfiguration> _popupQueue = null;

        public void OpenPopup(PopupType type)
        {
            PopupConfiguration config = _popupContainer.GetPopupConfig(type);

            if (config == null)
            {
                Debug.LogError("NO SUCH A PREFAB FOUND");
                return;
            }

            if (_openedPopups.Count > 0)
            {
                _popupQueue.Enqueue(config);
                return;
            }

            SpawnPopup(config);
        }
        private void SpawnPopup(PopupConfiguration config)
        {
            GameObject popupObject = Resources.Load<GameObject>(config.PrefabName);
            RectTransform parent = _uiRoot.GetUIRoot(UIRootType.PopupsRoot);
            
            config.Implementation = Object.Instantiate(popupObject, parent);
            _openedPopups.Add(config);
        }

        public void ClosePopup(PopupType type)
        {
            PopupConfiguration config = _popupContainer.GetPopupConfig(type);
            if (_openedPopups.Contains(config))
            {
                Object.Destroy(config.Implementation);
                _openedPopups.Remove(config);
            }
        }

        public void ClosePopupOnTop()
        {
        }

    }
}