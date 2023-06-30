using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.PopupNextQuestionScript
{
    [Serializable]
    public class PopupNextQuestionModel
    {
        [SerializeField] private TMP_Text _headerLable;
        [SerializeField] private TMP_Text _popupNextQuestionInfoText;
        [SerializeField] private TMP_Text _playButtonText;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _backToMainMenu;

        public TMP_Text HeaderLable { get { return _headerLable; } set { } }
        public TMP_Text PopupNextQuestionInfoText { get { return _popupNextQuestionInfoText; } set { } }
        public TMP_Text PlayButtonText { get {  return _playButtonText; } set { } }
        public Button PlayButton { get { return _playButton; } }
        public Button BackToMainMenu { get {  return _backToMainMenu; } }
    }
}
