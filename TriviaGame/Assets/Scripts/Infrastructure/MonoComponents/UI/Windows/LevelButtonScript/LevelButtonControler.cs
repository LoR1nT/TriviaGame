namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelButtonScript
{
    public class LevelButtonControler
    {
        private LevelButtonModel _levelButtonModel;

        public LevelButtonControler(LevelButtonModel levelButtonModel)
        {
            _levelButtonModel = levelButtonModel;
        }

        public void Initialize()
        {
            _levelButtonModel.LevelButton.onClick.AddListener(StartLevel);
        }

        private void StartLevel()
        {

        }

        public void Dispose()
        {
            _levelButtonModel.LevelButton.onClick.RemoveAllListeners();
        }
    }
}
