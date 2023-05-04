using Assets.Scripts.Infrastructure.Services.WindowsService.Container;
using Assets.Scripts.Infrastructure.Services.WindowsService.Data;
using Infrastructure.MonoComponents.UI.UIRoot;
using Infrastructure.MonoComponents.UI.UIRoot.Data;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.WindowsService.Implementation
{
    public class WindowsService
    {
        public bool HasAnyScreanOpened => _windowsConfigurations.Count > 0;

        private readonly IWindowsContainer _windowsContainer;
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
            GameObject windowsOdject = Resources.Load<GameObject>(configuration.PrefabName);
            RectTransform windowRectTransform = _uiRoot.GetUIRoot(UIRootType.WindowsRoot);

            configuration.Implementation = Object.Instantiate(windowsOdject,windowRectTransform);
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
