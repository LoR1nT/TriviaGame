using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation
{
    public interface IAssetProvider
    {
        public GameObject GetObject(string PrefabName);
    }
}
