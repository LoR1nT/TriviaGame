using Infrastructure.Services.Screans.Data;
using Infrastructure.Services.Screans.Implementation;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.LevelsScreanScript
{
    public class LevelsScreanControler
    {
        private LevelsScreanModel _levelsScreanModel;
        private IScreanService _screenService;

        public LevelsScreanControler(LevelsScreanModel levelsScreanModel,IScreanService screanService)
        {
            _levelsScreanModel = levelsScreanModel;
            _screenService = screanService;
        }

        public void Initialize()
        {
            _levelsScreanModel.BackButton.onClick.AddListener(GoBack);
        }

        private void GoBack()
        {
            Dispose();
            _screenService.CloseScrean(ScreanType.LevelsScrean);
            Debug.Log("GoBack");
        }

        public void Dispose()
        {
            _levelsScreanModel.BackButton.onClick.RemoveAllListeners();
        }
    }
}
