using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelButtonScript
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private LevelButtonModel _levelButtonModel;
        private LevelButtonControler _levelButtonControler;

        private void Awake()
        {
            _levelButtonControler = new LevelButtonControler(_levelButtonModel);
            
        }

        private void Start()
        {
            _levelButtonControler.Initialize();
        }

        public void Data(int level, int score = 0)
        {
            _levelButtonControler.DataTransfer(level, score);
        }

        private void OnDestroy()
        {
            _levelButtonControler.Dispose();
        }
    }
}