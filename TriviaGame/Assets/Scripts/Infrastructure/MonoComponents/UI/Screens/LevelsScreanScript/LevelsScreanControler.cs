using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelSwithScript;
using Assets.Scripts.Infrastructure.Services.EventHolder.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelDataBase.Data;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using DG.Tweening;
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
        private ILevelGamePlayService _levelGamePlayService;
        private IEventHolderService _eventHolderService;
        private readonly int _minLengthOfTimeBar = 5;
        private readonly float _timerForAnswer = 15f;
        private Sequence _timerBarSequence = null;

        public LevelsScreanControler(LevelsScreanModel levelsScreanModel,
            IScreanService screanService,
            IWindowsService windowsService,
            ILevelGamePlayService levelGamePlayService,
            IEventHolderService eventHolderService)
        {
            _levelsScreanModel = levelsScreanModel;
            _screenService = screanService;
            _windowsService = windowsService;
            _eventHolderService = eventHolderService;
            _levelGamePlayService = levelGamePlayService;
        }

        public void Initialize()
        {
            _levelsScreanModel.BackButton.onClick.AddListener(GoBack);
            CreateTimerSequence();
            InitializeEvent();
            _timerBarSequence.Play();
        }

        public void OpenScreen()
        {
            SpawnButtonsWindow();
            _levelsScreanModel.PlayLevelHeader.SetActive(false);
        }

        private void InitializeEvent()
        {
            _eventHolderService.OnLevelStartEvent += OnLevelStart;
            _eventHolderService.OnSwitchLevelMenuViewEvent += OnSwitchLevelMenuView;            
        }

        private void UpdateScore()
        {            
            _levelsScreanModel.PlayLevelHeaderScoreCorrectCountText.text = _levelGamePlayService.GetScoreCorrect().ToString();
            _levelsScreanModel.PlayLevelHeaderScoreInCorrectCountText.text = _levelGamePlayService.GetScoreInCorrect().ToString();
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

        private void OnSwitchLevelMenuView(bool isMenuView)
        {
            _levelsScreanModel.LevelSwithHeader.SetActive(isMenuView);
        }

        private void OnLevelStart()
        {
            _levelsScreanModel.PlayLevelHeader.SetActive(true);
            _timerBarSequence.Restart();
            UpdateScore();
            Debug.Log("Level Start");
        }


        private void CreateTimerSequence()
        {
            _timerBarSequence = DOTween.Sequence();
            _timerBarSequence.SetRecyclable(true);
            _timerBarSequence.AppendInterval(0.5f);
            _timerBarSequence.Append(TimeBarAnimation()); ;
            _timerBarSequence.AppendInterval(0.2f);
            _timerBarSequence.AppendCallback(() =>
            {
                _levelGamePlayService.TimeOut();
                Debug.Log("Time is Out");
            });
        }

        private Tween TimeBarAnimation()
        {
            return _levelsScreanModel.TimeBarFill
            .DOSizeDelta(new Vector2(_minLengthOfTimeBar, _levelsScreanModel.TimeBarFill.sizeDelta.y), _timerForAnswer)
            .SetEase(Ease.Linear)
            .SetRecyclable(true);
        }

        public void Dispose()
        {
            _eventHolderService.OnLevelStartEvent -= OnLevelStart;
            _eventHolderService.OnSwitchLevelMenuViewEvent -= OnSwitchLevelMenuView;
            _levelsScreanModel.BackButton.onClick.RemoveAllListeners();
        }
    }
}
