using DG.Tweening;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Windows.PlayLavelScript
{
    public class PlayLavelControler
    {
        private PlayLavelModel _playLavelModel;
        private readonly int _minLengthOfTimeBar = 5;
        private readonly float _timerForAnswer = 30f;

        public PlayLavelControler(PlayLavelModel playLavelModel)
        {
            _playLavelModel = playLavelModel;
        }

        public void Initialize()
        {
            TimerStart();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            _playLavelModel.FirstButton.onClick.AddListener(FirstAnswer);
            _playLavelModel.SecondButton.onClick.AddListener(SecondAnswer);
            _playLavelModel.ThirdButton.onClick.AddListener(ThirdAnswer);
            _playLavelModel.FourthButton.onClick.AddListener(FourthAnswer);
        }

        private void FirstAnswer()
        {
            Debug.Log("FirstAnswer");
        }

        private void SecondAnswer()
        {
            Debug.Log("SecondAnswer");
        }

        private void ThirdAnswer()
        {
            Debug.Log("ThirdAnswer");
        }

        private void FourthAnswer()
        {
            Debug.Log("FourthAnswer");
        }

        private void TimerStart()
        {
            Sequence loadingBarSequence = DOTween.Sequence();
            loadingBarSequence.SetRecyclable(true);
            loadingBarSequence.AppendInterval(0.5f);
            loadingBarSequence.Append(TimeBarAnimation()); ;
            loadingBarSequence.AppendInterval(0.2f);
            loadingBarSequence.AppendCallback(() =>
            {
                Debug.Log("Time is Out");
            });
        }

        private Tween TimeBarAnimation()
        {
            return _playLavelModel.TimeBarFill
            .DOSizeDelta(new Vector2(_minLengthOfTimeBar, _playLavelModel.TimeBarFill.sizeDelta.y), _timerForAnswer)
            .SetEase(Ease.Linear)
            .SetRecyclable(true);
        }

        public void Dispose()
        {
            DisposeButtons();
        }
        private void DisposeButtons()
        {
            _playLavelModel.FirstButton.onClick.RemoveAllListeners();
            _playLavelModel.SecondButton.onClick.RemoveAllListeners();
            _playLavelModel.ThirdButton.onClick.RemoveAllListeners();
            _playLavelModel.FourthButton.onClick.RemoveAllListeners();
        }
    }
}
