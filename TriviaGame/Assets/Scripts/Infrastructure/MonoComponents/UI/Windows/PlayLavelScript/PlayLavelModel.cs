using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.MonoComponents.UI.Windows.PlayLavelScript
{
    [Serializable]
    public class PlayLavelModel
    {
        [SerializeField] private Button _firstButton;
        [SerializeField] private Image _firstButtonImage;
        [SerializeField] private Button _secondButton;
        [SerializeField] private Image _secondButtonImage;
        [SerializeField] private Button _thirdButton;
        [SerializeField] private Image _thirdButtonImage;
        [SerializeField] private Button _fourthButton;
        [SerializeField] private Image _fourthButtonImage;
        [SerializeField] private TMP_Text _questionText;
        [SerializeField] private List<TMP_Text> _answers;


        public Button FirstButton { get { return _firstButton;} }
        public Image FirstButtonImage { get { return _firstButtonImage;} }
        public Button SecondButton { get { return _secondButton;} }
        public Image SecondButtonImage { get { return _secondButtonImage;} }
        public Button ThirdButton { get { return _thirdButton;} }
        public Image ThirdButtonImage { get { return _thirdButtonImage;} }
        public Button FourthButton { get { return _fourthButton;} }
        public Image FourthButtonImage { get { return _fourthButtonImage; } }
        public List<TMP_Text> Answers { get { return _answers; } set { } }
        public TMP_Text QuesionText { get { return _questionText; } set { } }
    }
}
