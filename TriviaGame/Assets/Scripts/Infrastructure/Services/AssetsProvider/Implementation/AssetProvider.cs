using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject GetObject(string PrefabName)
        {
            return Resources.Load<GameObject>(PrefabName);
        }
    }
}
