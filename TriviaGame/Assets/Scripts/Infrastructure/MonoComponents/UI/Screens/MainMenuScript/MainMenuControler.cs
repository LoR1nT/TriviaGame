using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Screens.MainMenuScript
{
    public class MainMenuControler
    {
        private MainMenuModel _mainMenuModel;

        public MainMenuControler(MainMenuModel mainMenuModel)
        {
            _mainMenuModel = mainMenuModel;
        }

        public void Initialize()
        {
            _mainMenuModel.PlayButton.onClick.AddListener(PlayGame);
            _mainMenuModel.SettingsButton.onClick.AddListener(OpenSettings);
            _mainMenuModel.AchievementsButton.onClick.AddListener(OpenAchievements);
        }

        private void OpenSettings()
        {
            Debug.Log("OpenSettings");
            _mainMenuModel.PopupSettings.SetActive(true);
        }

        private void OpenAchievements()
        {
            Debug.Log("OpenAchievements");
        }

        private void PlayGame()
        {
            Debug.Log("PlayGame");
            _mainMenuModel.LevelSwith.SetActive(true);
        }

        public void Dispose()
        {
            _mainMenuModel.MainMenu.SetActive(false);
            _mainMenuModel.PlayButton.onClick.RemoveAllListeners();
            _mainMenuModel.AchievementsButton.onClick.RemoveAllListeners();
            _mainMenuModel.SettingsButton.onClick.RemoveAllListeners();
        }
    }
}
