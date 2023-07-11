using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.LevelsScreanScript
{
    [Serializable]
    public class LevelsScreanModel
    {
        [SerializeField] private GameObject _levelSwithHeader;
        [SerializeField] private GameObject _playLevelHeader;
        [SerializeField] private Button _backButton;
        [SerializeField] private RectTransform _timeBarFill;
        [SerializeField] private TMP_Text _playLevelHeaderScoreCorrectCountText;
        [SerializeField] private TMP_Text _playLevelHeaderScoreInCorrectCountText;
        [SerializeField] private TMP_Text _playLevelHeaderScoreMaxCountText;

        public GameObject LevelSwithHeader { get { return _levelSwithHeader; } }
        public GameObject PlayLevelHeader { get { return _playLevelHeader; } }
        public Button BackButton { get { return _backButton;} }
        public RectTransform TimeBarFill { get {  return _timeBarFill; } set { } }
        public TMP_Text PlayLevelHeaderScoreCorrectCountText { get { return _playLevelHeaderScoreCorrectCountText;} set { } }
        public TMP_Text PlayLevelHeaderScoreInCorrectCountText { get { return _playLevelHeaderScoreInCorrectCountText;} set { } }
        public TMP_Text PlayLevelHeaderScoreMaxCountText { get { return _playLevelHeaderScoreMaxCountText;} set { } }
    }
}
