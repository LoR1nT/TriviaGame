using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelSwithScript;
using Infrastructure.Services.Screans.Data;
using Infrastructure.Services.Screans.Implementation;
using Infrastructure.Services.Windows.Data;
using Infrastructure.Services.Windows.Implementation;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.LevelsScreanScript
{
    public class LevelsScreanControler
    {
        private LevelsScreanModel _levelsScreanModel;
        private IScreanService _screenService;
        private IWindowsService _windowsService;

        public LevelsScreanControler(LevelsScreanModel levelsScreanModel,IScreanService screanService, IWindowsService windowsService)
        {
            _levelsScreanModel = levelsScreanModel;
            _screenService = screanService;
            _windowsService = windowsService;
        }

        public void Initialize()
        {
            _levelsScreanModel.BackButton.onClick.AddListener(GoBack);
        }

        public void OpenScreen()
        {
            SpawnButtonsWindow();
        }

        private void SpawnButtonsWindow()
        {
            Debug.Log("Spawning LevelSwitch window");
            _windowsService.OpenWindow<LevelSwith>(WindowsType.LevelSwitch);
        }

        private void GoBack()
        {
            _screenService.CloseScrean(ScreanType.LevelsScrean);
            _windowsService.CloseWindow(WindowsType.LevelSwitch);
            Debug.Log("GoBack");
        }

        public void Dispose()
        {
            _levelsScreanModel.BackButton.onClick.RemoveAllListeners();
        }
    }
}
