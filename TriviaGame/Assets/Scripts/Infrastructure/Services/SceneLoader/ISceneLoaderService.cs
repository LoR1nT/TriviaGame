using Infrastructure.Services.SevicesLocator;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoaderService : IService
    {
        void LoadScene(string sceneName, LoadSceneMode loadSceneMode);
    }
}