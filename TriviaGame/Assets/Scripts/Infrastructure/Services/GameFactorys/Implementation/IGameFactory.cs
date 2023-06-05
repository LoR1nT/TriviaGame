using Infrastructure.Services.SevicesLocator;
using System;
using UnityEngine;


namespace Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation
{
    public interface IGameFactory : IService
    {
        public T Create<T>(GameObject prefab);
        public T Create<T>(GameObject prefab, Transform rectTransform);
    }
}
