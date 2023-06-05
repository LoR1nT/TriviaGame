using System.Collections.Generic;
using Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.Base;
using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation;
using Infrastructure.MonoComponents.UI.UIRoot;
using Infrastructure.MonoComponents.UI.UIRoot.Data;
using Infrastructure.Services.Popups.Container;
using Infrastructure.Services.Popups.Data;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Infrastructure.Services.Popups.Implementation
{
    public class PopupService : IPopupService
    {
        public bool HasAnyPopupsOpened => _openedPopups.Count > 0;

        private readonly IPopupContainer _popupContainer = null;
        private readonly IUIRoot _uiRoot = null;
        private readonly IAssetProvider _assetProvider;
        private readonly IGameFactory _gameFactory;
        private List<PopupConfiguration> _openedPopups = null;
        private Queue<PopupConfiguration> _popupQueue = null;

        public PopupService(IPopupContainer popupContainer, IUIRoot uiRoot, IAssetProvider assetProvider, IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _assetProvider = assetProvider;
            _popupContainer = popupContainer;
            _uiRoot = uiRoot;
            
            _openedPopups = new List<PopupConfiguration>(4);
            _popupQueue = new Queue<PopupConfiguration>(4);
        }

        public void OpenPopup<TPopup>(PopupType type) where TPopup : BasePopup
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

            SpawnPopup<TPopup>(config);
            
            config.Implementation.Initialize();
            config.Implementation.Open();
        }
        private void SpawnPopup<TPopup>(PopupConfiguration config) where TPopup : BasePopup
        {
            GameObject popupObject = _assetProvider.GetAsset<GameObject>(config.PrefabName);
            RectTransform parent = _uiRoot.GetUIRoot(UIRootType.PopupsRoot);
            
            config.Implementation = _gameFactory.Create<TPopup>(popupObject,parent);
            _openedPopups.Add(config);
        }

        public void ClosePopup(PopupType type)
        {
            PopupConfiguration config = _popupContainer.GetPopupConfig(type);
            if (_openedPopups.Contains(config))
            {
                config.Implementation.Dispose();
                config.Implementation.Close();
                _openedPopups.Remove(config);
            }
        }

        public void ClosePopupOnTop()
        {
            PopupConfiguration _popupOnTopConfig = _popupQueue.Dequeue();
            if (_openedPopups.Contains(_popupOnTopConfig))
            {
                _popupOnTopConfig.Implementation.Dispose();
                _popupOnTopConfig.Implementation.Close();
            }
        }

    }
}