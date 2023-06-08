using System;
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

        public GameObject LevelSwithHeader { get { return _levelSwithHeader; } }
        public GameObject PlayLevelHeader { get { return _playLevelHeader; } }
        public Button BackButton { get { return _backButton;} }
    }
}
