﻿using System;
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
        [SerializeField] private GameObject _popupSettings;
        [SerializeField] private GameObject _levelSwith;
        [SerializeField] private GameObject _mainMenu;

        public Button PlayButton { get { return _playButton; } }
        public Button AchievementsButton { get { return _achievementsButton; } }
        public Button SettingsButton { get { return _settingsButton; } }
        public GameObject PopupSettings { get { return _popupSettings; } }
        public GameObject LevelSwith { get { return _levelSwith; } }
        public GameObject MainMenu { get { return _mainMenu;} }

    }
}