using Assets.Scripts.Infrastructure.MonoComponents.ScriptableObjects.Configurations.Level;
using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelDataBase.Data;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.Services.LevelDataBase.Implementation
{
    public class LevelDataBaseService : ILevelDataBaseService
    {
        private IAssetProvider _assetProvider;
        private const string _dataPath = "Configurations/Level/Level_Data_Configurations";
        private List<LevelData> _currentLevels;

        public LevelDataBaseService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            Initialize();
        }

        public LevelData GetCurrentLevelData(int levelIndex)
        {
            foreach(var levelData in _currentLevels)
            {
                if(levelData.Index == levelIndex)
                {
                    return levelData;
                }
            }
            return null;
        }

        private void Initialize()
        {
            LevelDataConfiguration levelDataConfiguration = _assetProvider.GetAsset<LevelDataConfiguration>(_dataPath);
            _currentLevels = levelDataConfiguration.LevelsData;
            
        }
    }
}
