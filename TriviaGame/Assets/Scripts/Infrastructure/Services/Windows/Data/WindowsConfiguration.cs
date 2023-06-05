using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.Base;
using UnityEngine;

namespace Infrastructure.Services.Windows.Data
{
    public class WindowsConfiguration
    {
        public string WindowsName { get; } = string.Empty;
        public string PrefabName { get; } = string.Empty;
        public BaseWindows Implementation { get; set; }

        public WindowsConfiguration(string name, string prefabName)
        {
            WindowsName = name;
            PrefabName = prefabName;
        }
    }
}
