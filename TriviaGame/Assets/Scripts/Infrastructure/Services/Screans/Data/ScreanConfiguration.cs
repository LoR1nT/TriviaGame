using Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.Base;
using UnityEngine;
using UnityEngine.Device;

namespace Infrastructure.Services.Screans.Data
{
    public class ScreanConfiguration
    {
        public string ScreanName { get; } = string.Empty;
        public string PrefabName { get; } = string.Empty;
        public BaseScreen Implementation { get; set; }

        public ScreanConfiguration(string name, string prefabName)
        {
            ScreanName = name;
            PrefabName = prefabName;
        }
    }
}
