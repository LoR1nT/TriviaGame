using Assets.Scripts.Infrastructure.Services.EventHolder.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using Infrastructure.Services.Windows.Data;
using Infrastructure.Services.Windows.Implementation;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelButtonScript
{
    public class LevelButtonControler
    {
        private readonly LevelButtonModel _levelButtonModel;
        private int _levelButtonIndex;
        private int _levelButtonScore = 0;
        private readonly IWindowsService _windowsService;
        private ILevelGamePlayService _levelGamePlayService;
        private IEventHolderService _eventHolderService;

        public LevelButtonControler(LevelButtonModel levelButtonModel,
            IWindowsService windowsService,
            ILevelGamePlayService levelGamePlayService,
            IEventHolderService eventHolderService)
        {
            _eventHolderService = eventHolderService;
            _levelGamePlayService = levelGamePlayService;
            _levelButtonModel = levelButtonModel;
            _windowsService = windowsService;
        }

        public void Initialize()
        {
            _levelButtonModel.LevelButton.onClick.AddListener(StartLevel);
            ChangeUIText();
            ChangeUIScore();
        }

        private void ChangeUIText()
        {
            _levelButtonModel.NumberOfLevelText.text = (_levelButtonIndex + 1).ToString();
        }


        private void StartLevel()
        {
            _levelGamePlayService.StartNewLevel(_levelButtonIndex);
            _eventHolderService.OnSwitchLevelMenuView(false);
            _windowsService.CloseWindow(WindowsType.LevelSwitch);
        }

        private void ChangeUIScore()
        {
            switch (_levelButtonScore)
            {
                case 0:
                    _levelButtonModel.ScoreImage.sprite = _levelButtonModel.NoStars;
                    break;
                case 1:
                    _levelButtonModel.ScoreImage.sprite = _levelButtonModel.OneStars;
                    break;
                case 2:
                    _levelButtonModel.ScoreImage.sprite = _levelButtonModel.TwoStars;
                    break;
                case 3:
                    _levelButtonModel.ScoreImage.sprite = _levelButtonModel.ThreeStars;
                    break;
            }
        }

        private void ChangeUIState()
        {

        }

        public void DataTransfer(int level)
        {
            _levelButtonIndex = level;
        }

        public void Dispose()
        {
            _levelButtonModel.LevelButton.onClick.RemoveAllListeners();
        }
    }
}
