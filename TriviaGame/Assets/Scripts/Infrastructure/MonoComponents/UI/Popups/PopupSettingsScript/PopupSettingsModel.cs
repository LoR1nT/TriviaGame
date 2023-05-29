using System;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.MonoComponents.UI.Popups.PopupSettingsScript
{
    [Serializable]
    public class PopupSettingsModel
    {
        [SerializeField] private Slider _bgmSlider;
        [SerializeField] private Slider _soundEffectSlider;
        [SerializeField] private Button _languageChange;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Image _bmgHandle;
        [SerializeField] private Image _soundEffectHandle;

        public Slider BGMSlider { get { return _bgmSlider; } }
        public Slider SoundEffectSlider { get { return _soundEffectSlider; } }
        public Button LanguageChange { get { return _languageChange;} }
        public Button CloseButton { get { return _closeButton;} }
        public Image BMGHandle { get { return _bmgHandle; } }
        public Image SoundEffectHandle { get { return _soundEffectHandle;} }
    }
}
