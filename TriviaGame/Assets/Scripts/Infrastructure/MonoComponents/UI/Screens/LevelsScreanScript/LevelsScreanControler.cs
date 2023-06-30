using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelSwithScript;
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
        private readonly int _minLengthOfTimeBar = 5;
        private readonly float _timerForAnswer = 15f;
        public bool _state = true;
        private Sequence _timerBarSequence = null;

        public LevelsScreanControler(LevelsScreanModel levelsScreanModel,IScreanService screanService, IWindowsService windowsService, ILevelGamePlayService levelGamePlayService)
        {
            _levelsScreanModel = levelsScreanModel;
            _screenService = screanService;
            _windowsService = windowsService;
            _levelGamePlayService = levelGamePlayService;
        }

        public void Initialize()
        {
            _levelsScreanModel.BackButton.onClick.AddListener(GoBack);
            CreateTimerSequence();
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

        public void ChangeHeader()
        {
            if (_levelGamePlayService.CheckStateIsStart() && _state == true)
            {
                _levelsScreanModel.LevelSwithHeader.SetActive(false);
            }

            if (_levelGamePlayService.CheckStateIsInGame() && (_state == true))
            {
                _levelsScreanModel.PlayLevelHeader.SetActive(true);
                _timerBarSequence.Play();
                Debug.Log("Animation Start");
                _state = false;

            }
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
                _levelGamePlayService.CheckTime(true);
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
            _levelsScreanModel.BackButton.onClick.RemoveAllListeners();
        }
    }
}
