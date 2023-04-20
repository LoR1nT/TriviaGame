using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.LevelSwithScript
{
    public class LevelSwithControler
    {
        private readonly LevelSwithModel _levelSwithModel;
        //private LevelButtons _levelButtons;

        public LevelSwithControler(LevelSwithModel levelSwithModel)
        {
            _levelSwithModel = levelSwithModel;
            //_levelButtons = levelButtons;
        }

        public void Initialize()
        {
            _levelSwithModel.MainMenu.SetActive(false);
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            _levelSwithModel.BackButton.onClick.AddListener(ReturnBack);
            
            for (int i = 0; i < _levelSwithModel.LevelsButtons.Count; i++)
            {
                int ButtonID = i + 1;
                _levelSwithModel.LevelsButtons[i].onClick.AddListener(() => StartLevel(ButtonID));
            }
        }

        private void ReturnBack()
        {
            Debug.Log("ReturnBack");
            Dispose();
        }

        private void StartLevel(int ButtonID)
        {
            Debug.Log("Запуск уровня: " + ButtonID);
        }


        public void Dispose()
        {
            _levelSwithModel.MainMenu.SetActive(true);
            _levelSwithModel.LevelSwithScrean.SetActive(false);
            DisposeButtons();
        }

        private void DisposeButtons()
        {
            _levelSwithModel.BackButton.onClick.RemoveAllListeners();
            foreach (Button LevelsButtons in _levelSwithModel.LevelsButtons)
            {
                LevelsButtons.onClick.RemoveAllListeners();
            }
        }
    }
}
