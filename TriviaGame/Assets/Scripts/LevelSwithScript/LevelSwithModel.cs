using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.LevelSwithScript
{
    [Serializable]
    public class LevelSwithModel
    {
        [SerializeField] private GameObject _levelSwithScrean;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_Text _reachedContOfStars;
        [SerializeField] private TMP_Text _maxCountOfStars;
        [SerializeField] private List<Button> _levelsButtons;

        public GameObject LevelSwithScrean { get { return _levelSwithScrean; } }
        public GameObject MainMenu { get { return _mainMenu; } }
        public Button BackButton { get { return _backButton; } }
        public TMP_Text ReachedContOfStars { get { return _reachedContOfStars; } }
        public TMP_Text MaxCountOfStars { get { return _maxCountOfStars; } }
        public List<Button> LevelsButtons { get { return _levelsButtons; } }

    }
}
