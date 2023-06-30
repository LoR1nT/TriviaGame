using Assets.Scripts.Infrastructure.Services.LevelDataBase.Data;
using Infrastructure.Services.SevicesLocator;

namespace Assets.Scripts.Infrastructure.Services.LevelDataBase.Implementation
{
    public interface ILevelDataBaseService : IService
    {
        public LevelData GetCurrentLevelData(int levelIndex);
    }
}
