﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.ScreansService.Data
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
