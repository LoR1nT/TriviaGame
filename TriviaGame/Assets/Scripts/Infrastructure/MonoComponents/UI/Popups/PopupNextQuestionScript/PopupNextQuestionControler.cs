using Assets.Scripts.Infrastructure.Services.LevelDataBase.Data;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using Infrastructure.Services.Popups.Data;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.Screans.Data;
using Infrastructure.Services.Screans.Implementation;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.PopupNextQuestionScript
{
    public class PopupNextQuestionControler
    {
        private PopupNextQuestionModel _popupNextQuestionModel;
        private ILevelGamePlayService _levelGamePlayService;
        private IPopupService _popupService;
        private IScreanService _screanService;

        private LevelData _levelData;
        private QuestionData _questionData;

        public PopupNextQuestionControler(PopupNextQuestionModel popupNextQuestionModel, ILevelGamePlayService levelGamePlayService, IPopupService popupService, IScreanService screanService)
        {
            _levelGamePlayService = levelGamePlayService;
            _popupNextQuestionModel = popupNextQuestionModel;
            _screanService = screanService;
            _popupService = popupService;
        }

        public void Initialize()
        {
            InitializeButtons();
            InitializeText();
        }

        private void InitializeButtons()
        {
            _popupNextQuestionModel.PlayButton.onClick.AddListener(OpenQuestion);
            _popupNextQuestionModel.BackToMainMenu.onClick.AddListener(BackToMainMenu);
        }

        private void InitializeText()
        {
            _levelData = _levelGamePlayService.GetLevelData();
            _questionData = _levelGamePlayService.GetCurentQuestion();
            _popupNextQuestionModel.PopupNextQuestionInfoText.text = ("Question Number " + (_questionData.Index + 1).ToString());
            _popupNextQuestionModel.HeaderLable.text = ("Level " + (_levelData.Index + 1).ToString());
            AnswerCheckUI();
        }

        private void OpenQuestion()
        {
            _levelGamePlayService.OpenQuestion();
        }

        private void BackToMainMenu()
        {
            _screanService.CloseScrean(ScreanType.LevelsScrean);
            _popupService.ClosePopup(PopupType.NextQuestionPopup);
        }

        private void AnswerCheckUI()
        {
            if (_levelGamePlayService.CheckStateIsInGame())
            {
                if (_levelGamePlayService.IsAnswerWasRigth())
                {
                    _popupNextQuestionModel.PopupNextQuestionInfoText.text = "It is Rigth";
                    _popupNextQuestionModel.PlayButtonText.text = "Go to Next Question";
                }
                else
                {
                    _popupNextQuestionModel.PopupNextQuestionInfoText.text = "It is wrong";
                    _popupNextQuestionModel.PlayButtonText.text = "Go to Next Question";
                }
            }
        }

        public void Dispose()
        {
            _popupNextQuestionModel.PlayButton.onClick.RemoveAllListeners();
            _popupNextQuestionModel.BackToMainMenu.onClick.RemoveAllListeners();
        }
    }
}
