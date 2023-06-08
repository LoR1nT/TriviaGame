using System;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.MonoComponents.UI.Screens.MainMenuScript
{
    [Serializable]
    public class MainMenuModel
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _achievementsButton;
        [SerializeField] private Button _settingsButton;

        public Button PlayButton { get { return _playButton; } }
        public Button AchievementsButton { get { return _achievementsButton; } }
        public Button SettingsButton { get { return _settingsButton; } }

    }
}
