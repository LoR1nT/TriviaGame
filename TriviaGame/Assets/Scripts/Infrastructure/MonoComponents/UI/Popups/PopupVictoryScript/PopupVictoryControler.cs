using Assets.Scripts.Infrastructure.Services.EventHolder.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelDataBase.Data;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using DG.Tweening;
using Infrastructure.Services.Popups.Data;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.Screans.Data;
using Infrastructure.Services.Screans.Implementation;
using Infrastructure.Services.Windows.Data;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Popups.PopupVictoryScript
{
    public class PopupVictoryControler
    {
        private readonly PopupVictoryModel _popupVictoryModel;
        private int _amountOfStarsReached = 0;
        private IEventHolderService _eventHolderService;
        private IPopupService _popupService;
        private IScreanService _screanService;
        private ILevelGamePlayService _levelGamePlayService;
        private LevelData _levelData;
        private Sequence _loadingBarSequence = null;

        public PopupVictoryControler(PopupVictoryModel popupVictoryModel,
            IPopupService popupService,
            IScreanService screanService,
            IEventHolderService eventHolderService,
            ILevelGamePlayService levelGamePlayService)
        {
            _popupVictoryModel = popupVictoryModel;
            _eventHolderService = eventHolderService;
            _levelGamePlayService = levelGamePlayService;
            _popupService = popupService;
            _screanService = screanService;
        }

        public void Initialize()
        {
            InitializeButtons();
            InitializeEvent();
            _levelData = _levelGamePlayService.GetLevelData();
            
        }

        private void InitializeButtons()
        {
            _popupVictoryModel.NextLavelButton.onClick.AddListener(GoToNextLavel);
            _popupVictoryModel.BackToMainMenuButton.onClick.AddListener(GoToMainMenu);
        }

        private void InitializeEvent()
        {
            _eventHolderService.OnLevelFinishEvent += OnLevelFinish;
        }

        private void GoToNextLavel()
        {
            Debug.Log("GoToNextLavel");
            _levelGamePlayService.StartNewLevel(_levelData.Index + 1);
            _eventHolderService.OnSwitchLevelMenuView(false);
            _popupService.ClosePopup(PopupType.VicrotyPopup);
        }

        private void GoToMainMenu()
        {
            Debug.Log("GoToMainMenu");
            _screanService.CloseScrean(ScreanType.LevelsScrean);
            _popupService.ClosePopup(PopupType.VicrotyPopup);
            _eventHolderService.OnSwitchLevelMenuView(true);
            _levelGamePlayService.QuitLevel();
        }

        private void OnLevelFinish(int numderOfStarsReached)
        {
            _amountOfStarsReached = numderOfStarsReached;
            CreateAmountOfStarsReachedSequence();
            _loadingBarSequence.Play();
        }

        public void OpenPopup()
        {

        }

        private void CreateAmountOfStarsReachedSequence()
        {
            _loadingBarSequence = DOTween.Sequence();
            _loadingBarSequence.SetRecyclable(true);
            _loadingBarSequence.AppendInterval(0.5f);
            switch (_amountOfStarsReached)
            {
                case 1:
                    _loadingBarSequence.Append(StarLeft()); ;
                    _loadingBarSequence.AppendInterval(0.1f);
                    break;
                case 2:
                    _loadingBarSequence.Append(StarLeft()); ;
                    _loadingBarSequence.AppendInterval(0.1f);
                    _loadingBarSequence.Append(StarCenter());
                    _loadingBarSequence.AppendInterval(0.1f);
                    break;
                case 3:
                    _loadingBarSequence.Append(StarLeft());
                    _loadingBarSequence.AppendInterval(0.1f);
                    _loadingBarSequence.Append(StarCenter());
                    _loadingBarSequence.AppendInterval(0.1f);
                    _loadingBarSequence.Append(StarRight());
                    _loadingBarSequence.AppendInterval(0.1f);
                    break;
            }

            _loadingBarSequence.AppendCallback(() =>
            {
                Debug.Log("Level Finished");
            });
        }
        private Tween StarLeft()
        {
            return _popupVictoryModel.StarLeft1
                .DOScale(new Vector2(1.0f, 1.0f), 0.3f)
                .SetEase(Ease.Linear)
                .SetRecyclable(true);
        }
        private Tween StarCenter()
        {
            return _popupVictoryModel.StarCenter1
                .DOScale(new Vector2(1.0f,1.0f), 0.3f)
                .SetEase(Ease.Linear)
                .SetRecyclable(true);
        }
        private Tween StarRight()
        {
            return _popupVictoryModel.StarRight1
                .DOScale(new Vector2(1.0f, 1.0f), 0.3f)
                .SetEase(Ease.Linear)
                .SetRecyclable(true);
        }


        public void Dispose()
        {
            _popupVictoryModel.NextLavelButton.onClick.RemoveAllListeners();
            _popupVictoryModel.BackToMainMenuButton.onClick.RemoveAllListeners();
            _eventHolderService.OnLevelFinishEvent -= OnLevelFinish;
        }
    }
}
