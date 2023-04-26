using System;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.MonoComponents.UI.Popups.PopupVictoryScript
{
    [Serializable]
    public class PopupVictoryModel
    {
        [SerializeField] private Button _nextLavelButton;
        [SerializeField] private Button _backToMainMenuButton;
        [SerializeField] private RectTransform _starCenter1;
        [SerializeField] private RectTransform _starLeft1;
        [SerializeField] private RectTransform _starRight1;

        public Button NextLavelButton { get { return _nextLavelButton; } }
        public Button BackToMainMenuButton { get {  return _backToMainMenuButton; } }
        public RectTransform StarCenter1 { get { return _starCenter1; } }
        public RectTransform StarLeft1 { get { return _starLeft1; } }
        public RectTransform StarRight1 { get { return _starRight1; } }

    }
}
