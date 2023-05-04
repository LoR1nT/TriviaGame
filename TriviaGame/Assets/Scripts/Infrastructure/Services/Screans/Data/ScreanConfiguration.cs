using UnityEngine;

namespace Infrastructure.Services.Screans.Data
{
    public class ScreanConfiguration
    {
        public string ScreanName { get; } = string.Empty;
        public string PrefabName { get; } = string.Empty;
        public GameObject Implementation { get; set; }

        public ScreanConfiguration(string name, string prefabName)
        {
            ScreanName = name;
            PrefabName = prefabName;
        }
    }
}
