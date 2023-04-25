using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.PlayLavelScript
{
    [Serializable]
    public class PlayLavelModel
    {
        [SerializeField] private RectTransform _timeBarFill;
        [SerializeField] private Button _firstButton;
        [SerializeField] private TMP_Text _firstAnswerText;
        [SerializeField] private Button _secondButton;
        [SerializeField] private TMP_Text _secondAnswerText;
        [SerializeField] private Button _thirdButton;
        [SerializeField] private TMP_Text _thidrAnswerText;
        [SerializeField] private Button _fourthButton;
        [SerializeField] private TMP_Text _fourthAnswerText;
        [SerializeField] private TMP_Text _questionText;
        [SerializeField] private TMP_Text _rightAnswersText;
        [SerializeField] private TMP_Text _wrongAnswersText;

        public RectTransform TimeBarFill { get { return _timeBarFill; } }
        public Button FirstButton { get { return _firstButton;} }
        public TMP_Text FirstAnswerText { get { return _firstAnswerText; } }
        public Button SecondButton { get { return _secondButton;} } 
        public TMP_Text SecondAnswerText {  get { return _secondAnswerText; } }
        public Button ThirdButton { get { return _thirdButton;} }
        public TMP_Text ThirdAnswerText { get { return _thidrAnswerText; } }
        public Button FourthButton { get { return _fourthButton;} }
        public TMP_Text FourthAnswerText { get { return _fourthAnswerText; } }
        public TMP_Text QuesionText { get { return _questionText; } }
        public TMP_Text RightAnswersText { get { return _rightAnswersText; } }
        public TMP_Text WrongAnswersText { get { return _wrongAnswersText; } }
    }
}
