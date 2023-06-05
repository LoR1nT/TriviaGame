using Infrastructure.Services.SevicesLocator;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation
{
    public interface IAssetProvider : IService
    {
        public T GetAsset<T>(string prefabName) where T : Object;
    }
}
