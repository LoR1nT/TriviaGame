using Assets.Scripts.Infrastructure.Services.LevelDataBase.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.ScriptableObjects.Configurations.Level
{
    [CreateAssetMenu(menuName = "Configurations/Level",fileName = "Level_Data_Configurations")]
    public class LevelDataConfiguration : ScriptableObject
    {
        [SerializeField] private List<LevelData> _levelData;

        public List<LevelData> LevelsData { get { return _levelData; } }
    }
}
