using UnityEngine;

namespace Infrastructure.Services.Popups.Data
{
    public class PopupConfiguration
    {
        public string PopupName { get; } = string.Empty;
        public string PrefabName { get; } = string.Empty;
        public GameObject Implementation { get; set; }

        public PopupConfiguration(string name, string prefabName)
        {
            PopupName = name;
            PrefabName = prefabName;
        }
    }
}