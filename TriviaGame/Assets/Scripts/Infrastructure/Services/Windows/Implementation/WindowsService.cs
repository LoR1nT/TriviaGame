using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.Base;
using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation;
using Infrastructure.MonoComponents.UI.UIRoot;
using Infrastructure.MonoComponents.UI.UIRoot.Data;
using Infrastructure.Services.Windows.Container;
using Infrastructure.Services.Windows.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.Windows.Implementation
{
    public class WindowsService : IWindowsService
    {
        public bool HasAnyScreanOpened => _windowsConfigurations.Count > 0;

        private readonly IWindowsContainer _windowsContainer;
        private readonly IAssetProvider _assetProvider;
        private readonly IGameFactory _gameFactory;
        private List<WindowsConfiguration> _windowsConfigurations = null;
        private IUIRoot _uiRoot = null;

        public WindowsService(IWindowsContainer windowsContainer, IUIRoot uiRoot, IAssetProvider assetProvider, IGameFactory gameFactory)
        {
            _assetProvider = assetProvider;
            _gameFactory = gameFactory;
            _uiRoot = uiRoot;
            _windowsContainer = windowsContainer;
            _windowsConfigurations = new List<WindowsConfiguration>();
        }

        public void OpenWindow<TWindow>(WindowsType type) where TWindow : BaseWindows
        {
            WindowsConfiguration configuration = _windowsContainer.GetWindowsConfig(type);

            if (configuration == null)
            {
                Debug.LogError("NO SUCH A PREFAB FOUND");
            }

            SpawnWindow<TWindow>(configuration);

        }



        private void SpawnWindow<TWindow>(WindowsConfiguration configuration) where TWindow : BaseWindows
        {
            GameObject windowsOdject = _assetProvider.GetAsset<GameObject>(configuration.PrefabName);
            RectTransform windowRectTransform = _uiRoot.GetUIRoot(UIRootType.WindowsRoot);

            configuration.Implementation = _gameFactory.Create<TWindow>(windowsOdject, windowRectTransform);
            _windowsConfigurations.Add(configuration);
            configuration.Implementation.Initialize();
            configuration.Implementation.Open();
        }

        public void CloseWindow(WindowsType type)
        {
            WindowsConfiguration configuration = _windowsContainer.GetWindowsConfig(type);

            if (_windowsConfigurations.Contains(configuration))
            {
                configuration.Implementation.Dispose();
                _windowsConfigurations.Remove(configuration);
                configuration.Implementation.Close();
            }

        }
    }
}
