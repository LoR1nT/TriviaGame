using Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.LevelsScreanScript;
using Infrastructure.MonoComponents.UI.Popups.PopupSettingsScript;
using Infrastructure.Services.Popups.Data;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.Screans.Data;
using Infrastructure.Services.Screans.Implementation;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Screens.MainMenuScript
{
    public class MainMenuControler
    {
        private MainMenuModel _mainMenuModel;
        private IScreanService _screanService;
        private IPopupService _popupService;

        public MainMenuControler(MainMenuModel mainMenuModel, IScreanService screanService,IPopupService popupService)
        {
            _mainMenuModel = mainMenuModel;
            _screanService = screanService;
            _popupService = popupService;
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
            _popupService.OpenPopup<PopupSettings>(PopupType.SettingsPopup);
        }

        private void OpenAchievements()
        {
            Debug.Log("OpenAchievements");
        }

        private void PlayGame()
        {
            Debug.Log("PlayGame");
            _screanService.OpenScrean<LevelsScrean>(ScreanType.LevelsScrean);
        }

        public void Dispose()
        {
            _mainMenuModel.PlayButton.onClick.RemoveAllListeners();
            _mainMenuModel.AchievementsButton.onClick.RemoveAllListeners();
            _mainMenuModel.SettingsButton.onClick.RemoveAllListeners();
        }
    }
}
