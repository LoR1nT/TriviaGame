using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation
{
    public class AssetProvider : IAssetProvider
    {
        public T GetAsset<T>(string PrefabName) where T : Object
        {
            return Resources.Load<T>(PrefabName);
        }
    }
}
