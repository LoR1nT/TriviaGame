using Assets.Scripts.Infrastructure.Services.EventHolder.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelDataBase.Data;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using Infrastructure.Services.Popups.Data;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.Screans.Data;
using Infrastructure.Services.Screans.Implementation;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Popups.PopupLostScript
{
    public class PopupLostControler
    {
        private readonly PopupLostModel _popupLostModel;
        private IEventHolderService _eventHolderService;
        private IPopupService _popupService;
        private IScreanService _screanService;
        private ILevelGamePlayService _levelGamePlayService;
        private LevelData _levelData;

        public PopupLostControler(PopupLostModel popupLostModel,
            IPopupService popupService,
            IScreanService screanService,
            IEventHolderService eventHolderService,
            ILevelGamePlayService levelGamePlayService)
        {
            _popupLostModel = popupLostModel;
            _eventHolderService = eventHolderService;
            _levelGamePlayService = levelGamePlayService;
            _popupService = popupService;
            _screanService = screanService;
        }

        public void Initialize()
        {
            InitializeButtons();
            _levelData = _levelGamePlayService.GetLevelData();
        }

        private void InitializeButtons()
        {
            _popupLostModel.BackToMainMenu.onClick.AddListener(BackToMainMenu);
            _popupLostModel.NextAtempt.onClick.AddListener(NextAtempt);
        }

        private void BackToMainMenu()
        {
            Debug.Log("BackToMainMenu");
            _screanService.CloseScrean(ScreanType.LevelsScrean);
            _popupService.ClosePopup(PopupType.LostPopup);
            _eventHolderService.OnSwitchLevelMenuView(true);
            _levelGamePlayService.QuitLevel();
        }

        private void NextAtempt()
        {
            Debug.Log("NextAtempt");
            _levelGamePlayService.StartNewLevel(_levelData.Index);
            _eventHolderService.OnSwitchLevelMenuView(false);
            _popupService.ClosePopup(PopupType.LostPopup);
        }

        public void Dispose()
        {
            _popupLostModel.BackToMainMenu.onClick.RemoveAllListeners();
            _popupLostModel.NextAtempt.onClick.RemoveAllListeners();
        }
    }
}
