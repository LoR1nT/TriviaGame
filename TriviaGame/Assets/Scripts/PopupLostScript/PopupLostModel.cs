using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.PopupLostScript
{
    [Serializable]
    public class PopupLostModel
    {
        [SerializeField] private Button _nextAtempt;
        [SerializeField] private Button _backToMainMenu;

        public Button NextAtempt { get { return _nextAtempt; } }
        public Button BackToMainMenu { get {  return _backToMainMenu; } }

    }
}
