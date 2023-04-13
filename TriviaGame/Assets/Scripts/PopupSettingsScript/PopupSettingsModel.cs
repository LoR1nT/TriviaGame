using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.PopupSettingsScript
{
    [Serializable]
    public class PopupSettingsModel
    {
        [SerializeField] private RectTransform _bgmRectTransform;
        [SerializeField] private RectTransform _soundEffectRectTransform;
        [SerializeField] private Button _bgmButton;
        [SerializeField] private Button _soundEffectButton;
        [SerializeField] private Button _languageChange;
        [SerializeField] private Button _closeButton;
        [SerializeField] private GameObject _popupSettings;

        public RectTransform BGMRectTransform { get { return _bgmRectTransform; } }

        public RectTransform SoundEffectRectTransform { get { return _soundEffectRectTransform; } }

        public Button LanguageChange { get { return _languageChange;} }

        public Button CloseButton { get { return _closeButton;} }

        public Button BGMButton { get { return _bgmButton; } }

        public Button SoundEffectButton { get { return _soundEffectButton; } }

        public GameObject PopUpSettings { get { return _popupSettings; } }
    }
}
