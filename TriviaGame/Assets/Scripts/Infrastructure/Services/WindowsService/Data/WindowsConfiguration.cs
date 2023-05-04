using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.WindowsService.Data
{
    public class WindowsConfiguration
    {
        public string WindowsName { get; } = string.Empty;
        public string PrefabName { get; } = string.Empty;
        public GameObject Implementation { get; set; }

        public WindowsConfiguration(string name, string prefabName)
        {
            WindowsName = name;
            PrefabName = prefabName;
        }
    }
}
