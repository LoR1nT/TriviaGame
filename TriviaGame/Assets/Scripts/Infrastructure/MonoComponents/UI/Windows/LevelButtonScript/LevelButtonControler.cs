namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelButtonScript
{
    public class LevelButtonControler
    {
        private LevelButtonModel _levelButtonModel;
        private int _levelButtonNumber;
        private int _levelButtonScore;

        public LevelButtonControler(LevelButtonModel levelButtonModel)
        {
            _levelButtonModel = levelButtonModel;
        }

        public void Initialize()
        {
            _levelButtonModel.LevelButton.onClick.AddListener(StartLevel);
            ChangeData();
        }

        private void ChangeData()
        {
            _levelButtonModel.NumberOfLevelText.text = _levelButtonNumber.ToString();
        }
                

        private void StartLevel()
        {

        }

        public void DataTransfer(int level, int score = 0)
        {
            _levelButtonNumber = level;
            _levelButtonScore = score;
        }

        public void Dispose()
        {
            _levelButtonModel.LevelButton.onClick.RemoveAllListeners();
        }
    }
}
