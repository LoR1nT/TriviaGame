using Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.PopupNextQuestionScript;
using Assets.Scripts.Infrastructure.Services.LevelDataBase.Data;
using Assets.Scripts.Infrastructure.Services.LevelDataBase.Implementation;
using Infrastructure.MonoComponents.UI.Windows.PlayLavelScript;
using Infrastructure.Services.Popups.Data;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.Windows.Data;
using Infrastructure.Services.Windows.Implementation;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation
{
    public class LevelGamePlayService : ILevelGamePlayService
    {
        private LevelData _curentLevelData;
        private readonly ILevelDataBaseService _levelDataBaseService;
        private int _curentLevelIndex;
        private int _curentQuestionIndex = 0;
        private readonly IWindowsService _windowsService;
        private readonly IPopupService _popupService;
        private bool _stateIsStart = false;
        private bool _stateInGame = false;
        private bool _currentAnswerState = false;
        //private int _countOfRightAnswers = 0;
        //private int _countOfWrongAnswer = 0;


        public LevelGamePlayService(IWindowsService windowsService, IPopupService popupService, ILevelDataBaseService levelDataBaseService)
        {
            _popupService = popupService;
            _levelDataBaseService = levelDataBaseService;
            _windowsService = windowsService;
        }

        public void StartNewLevel(int levelIndex)
        {
            _curentLevelIndex = levelIndex;
            _curentLevelData = _levelDataBaseService.GetCurrentLevelData(_curentLevelIndex);
            StartLevel();            
        }


        private void StartLevel()
        {
            _popupService.OpenPopup<PopupNextQuestion>(PopupType.NextQuestionPopup);
            _stateIsStart = true;
        }

        public void OpenQuestion()
        {
            _popupService.ClosePopup(PopupType.NextQuestionPopup);
            _windowsService.OpenWindow<PlayLavel>(WindowsType.PlayLavel);
            _stateInGame = true;
        }

        public QuestionData GetCurentQuestion()
        {
            return _curentLevelData.Questions[_curentQuestionIndex];
        }

        public LevelData GetLevelData()
        {
            return _curentLevelData;
        }

        public bool CheckAnswer(int answerIndex)
        {            
            foreach (var answerData in _curentLevelData.Questions[_curentQuestionIndex].Answers)
            {

                if (answerData.IsCorect && answerIndex == answerData.Index)
                {
                    Debug.Log("Right Answer");
                    _currentAnswerState = true;
                    _windowsService.CloseWindow(WindowsType.PlayLavel);
                    _popupService.ClosePopup(PopupType.NextQuestionPopup);
                    _popupService.OpenPopup<PopupNextQuestion>(PopupType.NextQuestionPopup);
                    _curentQuestionIndex++;
                    _currentAnswerState = false;
                    return true;
                }
                else
                {
                    Debug.Log("Wrong Answer");
                    _windowsService.CloseWindow(WindowsType.PlayLavel);
                    _popupService.OpenPopup<PopupNextQuestion>(PopupType.NextQuestionPopup);
                    _currentAnswerState = false;
                }
            }
            _curentQuestionIndex++;
            return false;
        }

        public bool IsAnswerWasRigth()
        {
            if (_currentAnswerState)
            {
                return true;
            }
            return false;
        }

        public bool CheckTime(bool isTimeOut)
        {
            if (isTimeOut)
                return true;
            return false;
        }

        public bool CheckStateIsStart()
        {
            if (_stateIsStart)
                return true;
            return false;
        }

        public bool CheckStateIsInGame()
        {
            if (_stateInGame)
                return true;
            return false;
        }
    }
}
