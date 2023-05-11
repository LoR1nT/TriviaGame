using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation;
using Infrastructure.MonoComponents.UI.UIRoot;
using Infrastructure.MonoComponents.UI.UIRoot.Data;
using Infrastructure.Services.Windows.Container;
using Infrastructure.Services.Windows.Data;
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

        public WindowsService(IWindowsContainer windowsContainer, IUIRoot uiRoot)
        {
            _uiRoot = uiRoot;
            _windowsContainer = windowsContainer;
        }

        public void OpenWindow(WindowsType type)
        {
            WindowsConfiguration configuration = _windowsContainer.GetWindowsConfig(type);

            if (configuration == null)
            {
                Debug.LogError("NO SUCH A PREFAB FOUND");
                return;
            }

            SpawnWindow(configuration);

        }

        private void SpawnWindow(WindowsConfiguration configuration)
        {
            GameObject windowsOdject = _assetProvider.GetObject(configuration.PrefabName);
            RectTransform windowRectTransform = _uiRoot.GetUIRoot(UIRootType.WindowsRoot);

            configuration.Implementation = _gameFactory.SpawnPrefab(windowsOdject,windowRectTransform);
            _windowsConfigurations.Add(configuration);
        }
        
        public void CloseWindow(WindowsType type)
        {
            WindowsConfiguration configuration = _windowsContainer.GetWindowsConfig(type);

            if (_windowsConfigurations.Contains(configuration))
            {
                Object.Destroy(configuration.Implementation);
                _windowsConfigurations.Remove(configuration);
            }

        }
    }
}
