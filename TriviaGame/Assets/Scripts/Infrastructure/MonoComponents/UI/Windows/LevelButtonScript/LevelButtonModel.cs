using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelButtonScript
{
    [Serializable]
    public class LevelButtonModel
    {
        [SerializeField] private Button _levelButton;
        [SerializeField] private TMP_Text _numberOfLevelText;
        [SerializeField] private Image _scoreImage;
        [SerializeField] private Sprite _noStars;
        [SerializeField] private Sprite _oneStars;
        [SerializeField] private Sprite _twoStars;
        [SerializeField] private Sprite _threeStars;

        public Button LevelButton { get { return _levelButton; } set { } }
        public TMP_Text NumberOfLevelText { get {  return _numberOfLevelText; } set { } }
        public Image ScoreImage { get { return _scoreImage;} set { } }
        public Sprite NoStars { get { return _noStars; } }
        public Sprite OneStars { get { return _oneStars; } }
        public Sprite TwoStars { get { return _twoStars; } }
        public Sprite ThreeStars { get { return _threeStars; } }
    }
}
