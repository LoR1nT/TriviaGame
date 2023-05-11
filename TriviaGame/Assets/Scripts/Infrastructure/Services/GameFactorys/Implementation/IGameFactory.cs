using System;
using UnityEngine;


namespace Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation
{
    public interface IGameFactory
    {
        public GameObject SpawnPrefab(GameObject prefab,RectTransform rectTransform);
    }
}
