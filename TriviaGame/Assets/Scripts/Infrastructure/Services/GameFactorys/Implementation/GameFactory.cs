using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation
{
    public class GameFactory : IGameFactory
    {
        public GameObject SpawnPrefab(GameObject prefab, RectTransform rectTransform)
        {
            return Object.Instantiate(prefab, rectTransform);
        }
    }
}
