using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation
{
    public class GameFactory : IGameFactory
    {
        public T Create<T>(GameObject prefab)
        {
            return Object.Instantiate(prefab).GetComponent<T>();
        }

        public T Create<T>(GameObject prefab, Transform rectTransform)
        {
            return Object.Instantiate(prefab, rectTransform).GetComponent<T>();
        }
    }
}
