using System;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.Base;
using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation;
using Infrastructure.MonoComponents.UI.UIRoot;
using Infrastructure.MonoComponents.UI.UIRoot.Data;
using Infrastructure.Services.Screans.Container;
using Infrastructure.Services.Screans.Data;
using UnityEngine;

namespace Infrastructure.Services.Screans.Implementation
{
    public class ScreanService : IScreanService
    {
        public bool HasAnyScreanOpened => _opendScreans.Count > 0;

        private readonly IScreanContainer _screanContainer;
        private readonly IAssetProvider _assetProvider;
        private readonly IGameFactory _gameFactory;
        private List<ScreanConfiguration> _opendScreans = null;
        private IUIRoot _uiRoot;
        private Action _onScreenClosedAction = null;

        public ScreanService(IScreanContainer screanContainer, IUIRoot uiRoot, IAssetProvider assetProvider, IGameFactory gameFactory)
        {
            _assetProvider = assetProvider;
            _gameFactory = gameFactory;
            _uiRoot = uiRoot;
            _screanContainer = screanContainer;

            _opendScreans = new List<ScreanConfiguration>();
        }

        public void OpenScrean<TScreen>(ScreanType type, Action onScreenClosed = null) where TScreen : BaseScreen
        {
            ScreanConfiguration config = _screanContainer.GetScreanConfig(type);
            
            if (config == null)
            {
                Debug.LogError("NO SUCH A PREFAB FOUND");
                return;
            }

            _onScreenClosedAction = onScreenClosed;
            
            SpawnScrean<TScreen>(config);
        }

        private void SpawnScrean<TScreen>(ScreanConfiguration config) where TScreen : BaseScreen
        {
            if (!HasOpenedScreen(config))
            {
                GameObject screanObject = _assetProvider.GetAsset<GameObject>(config.PrefabName);
                RectTransform screanRectTransform = _uiRoot.GetUIRoot(UIRootType.ScreensRoot);

                config.Implementation = _gameFactory.Create<TScreen>(screanObject, screanRectTransform);
            
                config.Implementation.Initialize();
                _opendScreans.Add(config);
            }
            
            config.Implementation.Open();
        }

        private bool HasOpenedScreen(ScreanConfiguration configuration)
        {
            if (_opendScreans.Contains(configuration))
            {
                return true;
            }

            return false;
        }

        public void CloseScrean(ScreanType type)
        {
            ScreanConfiguration config = _screanContainer.GetScreanConfig(type);
            if (_opendScreans.Contains(config))
            {
                config.Implementation.Hide();

                if (_onScreenClosedAction != null)
                {
                    _onScreenClosedAction.Invoke();
                }
            }
        }

    }
}
