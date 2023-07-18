using Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.PopupNextQuestionScript;
using Assets.Scripts.Infrastructure.Services.EventHolder.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelDataBase.Data;
using Assets.Scripts.Infrastructure.Services.LevelDataBase.Implementation;
using Infrastructure.MonoComponents.UI.Popups.PopupLostScript;
using Infrastructure.MonoComponents.UI.Popups.PopupVictoryScript;
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
        private readonly IWindowsService _windowsService;
        private readonly IPopupService _popupService;
        private readonly IEventHolderService _eventHolderService;

        private int _curentLevelIndex;
        private int _curentQuestionIndex = 0;
        private bool _stateInGame = false;
        private bool _currentAnswerState = false;
        private bool _timeOut = false;
        private int _scoreCorrect = 0;
        private int _scoreInCorrect = 0;


        public LevelGamePlayService(IWindowsService windowsService,
                                    IPopupService popupService,
                                    ILevelDataBaseService levelDataBaseService,
                                    IEventHolderService eventHolderService)
        {
            _popupService = popupService;
            _levelDataBaseService = levelDataBaseService;
            _eventHolderService = eventHolderService;
            _windowsService = windowsService;
        }

        public void StartNewLevel(int levelIndex)
        {
            _curentLevelIndex = levelIndex;
            Debug.Log("Start Level" + levelIndex);
            _curentLevelData = _levelDataBaseService.GetCurrentLevelData(_curentLevelIndex);
            StartLevel();            
        }


        private void StartLevel()
        {
            _popupService.OpenPopup<PopupNextQuestion>(PopupType.NextQuestionPopup);
            Debug.Log("OpenPopup");
        }

        public void OpenQuestion()
        {
            _popupService.ClosePopup(PopupType.NextQuestionPopup);
            _windowsService.OpenWindow<PlayLavel>(WindowsType.PlayLavel);
            _eventHolderService.OnLevelStart();
            _stateInGame = true;
        }

        public QuestionData GetCurentQuestion()
        {
            Debug.Log("Question Index" + _curentQuestionIndex);
            return _curentLevelData.Questions[_curentQuestionIndex];
        }

        public LevelData GetLevelData()
        {
            return _curentLevelData;
        }

        public bool CheckAnswer(int answerIndex)
        {
            if (_curentLevelData.Questions[_curentQuestionIndex].Answers[answerIndex].IsCorect)
            {
                Debug.Log("Right Answer");
                _currentAnswerState = true;
                _windowsService.CloseWindow(WindowsType.PlayLavel);
                Debug.Log("Next Question Index" + _curentQuestionIndex);
                _scoreCorrect++;
                if(_curentQuestionIndex < 9)
                {
                    _curentQuestionIndex++;
                    _popupService.OpenPopup<PopupNextQuestion>(PopupType.NextQuestionPopup);
                }
                else
                {
                    FinishLevel();
                }
                return true;
            }
            else
            {
                Debug.Log("Wrong Answer");
                _windowsService.CloseWindow(WindowsType.PlayLavel);
                _currentAnswerState = false;
                _scoreInCorrect++;
                Debug.Log("Next Question Index " + _curentQuestionIndex);
                if (_curentQuestionIndex < 9)
                {
                    _curentQuestionIndex++;
                    _popupService.OpenPopup<PopupNextQuestion>(PopupType.NextQuestionPopup);
                }
                else
                {
                    FinishLevel();
                }
                return false;
            }            
        }

        private void FinishLevel()
        {
            if(_scoreCorrect >= 5)
            {
                if(_scoreCorrect <= 7)
                {
                    _popupService.OpenPopup<PopupVictory>(PopupType.VicrotyPopup);
                    _eventHolderService.OnLevelFinish(1);
                    return;
                }
                else if(_scoreCorrect <= 9)
                {
                    _popupService.OpenPopup<PopupVictory>(PopupType.VicrotyPopup);
                    _eventHolderService.OnLevelFinish(2);
                    return;
                }
                else if( _scoreCorrect == 10)
                {
                    _popupService.OpenPopup<PopupVictory>(PopupType.VicrotyPopup);
                    _eventHolderService.OnLevelFinish(3);
                    return;
                }
            }
            else
            {
                _popupService.OpenPopup<PopupLost>(PopupType.LostPopup);
            }
        }

        public int GetScoreCorrect()
        {
            return _scoreCorrect;
        }

        public int GetScoreInCorrect()
        {
            return _scoreInCorrect;
        }

        public bool IsAnswerWasRigth()
        {
            if (_currentAnswerState)
            {
                return true;
            }
            return false;
        }

        public void TimeOut()
        {
            _timeOut = true;            
        }

        public bool CheckStateIsInGame()
        {
            if (_stateInGame)
                return true;
            return false;
        }

        public void QuitLevel()
        {
            _curentQuestionIndex = 0;
            _stateInGame = false;
            _timeOut = false;
        }
    }
}
