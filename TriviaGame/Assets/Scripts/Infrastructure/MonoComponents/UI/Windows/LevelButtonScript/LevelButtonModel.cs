using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Button LevelButton { get { return _levelButton; } }
        public TMP_Text NumberOfLevelText { get {  return _numberOfLevelText; } }
    }
}
