using System;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.MonoComponents.UI.Popups.PopupLostScript
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
