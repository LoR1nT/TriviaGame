using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.LevelsScreanScript
{
    [Serializable]
    public class LevelsScreanModel
    {
        [SerializeField] private GameObject _levelSwithHeader;
        [SerializeField] private GameObject _playLevelHeader;

        public GameObject LevelSwithHeader { get { return _levelSwithHeader; } }
        public GameObject PlayLevelHeader { get { return _playLevelHeader; } }
    }
}
