using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.Services.SceneLoader.Implementation
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public void LoadScene(string sceneName, LoadSceneMode loadSceneMode)
        {
            if (IsInSameScene(sceneName))
            {
                return;
            }

            SceneManager.LoadScene(sceneName, loadSceneMode);
        }

        private bool IsInSameScene(string sceneName)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            
            if (sceneName == currentSceneName)
            {
                return true;
            }

            return false;
        }
    }
}