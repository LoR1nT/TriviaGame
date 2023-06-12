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

        public Button LevelButton { get { return _levelButton; } set { } }
        public TMP_Text NumberOfLevelText { get {  return _numberOfLevelText; } set { } }
    }
}
