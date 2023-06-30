using Assets.Scripts.Infrastructure.Services.LevelDataBase.Data;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Windows.PlayLavelScript
{
    public class PlayLavelControler
    {
        private PlayLavelModel _playLavelModel;
        private ILevelGamePlayService _levelGamePlayService;
        private QuestionData _curentQuestion;

        public PlayLavelControler(PlayLavelModel playLavelModel, ILevelGamePlayService levelGamePlayService)
        {
            _levelGamePlayService = levelGamePlayService;
            _playLavelModel = playLavelModel;

        }

        public void Initialize()
        {
            InitializeData();
            InitializeButtons();
        }

        public void InitializeData()
        {
            _curentQuestion = _levelGamePlayService.GetCurentQuestion();
            InitializeText();
        }

        private void InitializeText()
        {
            _playLavelModel.QuesionText.text = _curentQuestion.Text;
            for (int i = 0; i < _playLavelModel.Answers.Count; i++)
            {
                _playLavelModel.Answers[i].text = _curentQuestion.Answers[i].Text;
            }
        }

        private void InitializeButtons()
        {
            _playLavelModel.FirstButton.onClick.AddListener(FirstAnswer);
            _playLavelModel.SecondButton.onClick.AddListener(SecondAnswer);
            _playLavelModel.ThirdButton.onClick.AddListener(ThirdAnswer);
            _playLavelModel.FourthButton.onClick.AddListener(FourthAnswer);
        }

        private void FirstAnswer()
        {
            int indexOfFirstAnswer = 0;
            if (_levelGamePlayService.CheckAnswer(indexOfFirstAnswer))
            {
                _playLavelModel.FirstButtonImage.color = Color.green;
            }
            else
            {
                _playLavelModel.FirstButtonImage.color = Color.red;
            }
        }

        private void SecondAnswer()
        {
            int indexOfSecondAnswer = 1;
            if (_levelGamePlayService.CheckAnswer(indexOfSecondAnswer))
            {
                _playLavelModel.SecondButtonImage.color = Color.green;
            }
            else
            {
                _playLavelModel.SecondButtonImage.color = Color.red;
            }
        }

        private void ThirdAnswer()
        {
            int indexOfThirdAnswer = 2;
            if (_levelGamePlayService.CheckAnswer(indexOfThirdAnswer))
            {
                _playLavelModel.ThirdButtonImage.color = Color.green;
            }
            else
            {
                _playLavelModel.ThirdButtonImage.color = Color.red;
            }
        }

        private void FourthAnswer()
        {
            int indexOfFourthAnswer = 3;
            if (_levelGamePlayService.CheckAnswer(indexOfFourthAnswer))
            {
                _playLavelModel.FourthButtonImage.color = Color.green;
            }
            else
            {
                _playLavelModel.FourthButtonImage.color = Color.red;
            }
        }



        public void Dispose()
        {
            DisposeButtons();
        }
        private void DisposeButtons()
        {
            _playLavelModel.FirstButton.onClick.RemoveAllListeners();
            _playLavelModel.SecondButton.onClick.RemoveAllListeners();
            _playLavelModel.ThirdButton.onClick.RemoveAllListeners();
            _playLavelModel.FourthButton.onClick.RemoveAllListeners();
        }
    }
}
