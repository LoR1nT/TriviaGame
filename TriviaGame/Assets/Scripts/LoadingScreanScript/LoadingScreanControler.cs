using System;
using System.Threading;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Sequence = DG.Tweening.Sequence;

namespace Assets.Scripts.LoadingScrean
{
    public class LoadingScreanControler
    {
        public const int MaxLengthOfBar = 990;
        private LoadingScreanModel _loadingScreanModel;

        public LoadingScreanControler(LoadingScreanModel loadingScreanModel)
        {
            _loadingScreanModel = loadingScreanModel;
        }

        public void Initialize()
        {
            LoadingBarChange();
        }

        private  void LoadingBarChange()
        {
            Sequence loadingBarSequence = DOTween.Sequence();
            loadingBarSequence.SetEase(Ease.Linear);
            loadingBarSequence.SetRecyclable(true);
            loadingBarSequence.AppendInterval(2f);
            loadingBarSequence.Append(LoadingBarAnimation());
            loadingBarSequence.Join(_loadingScreanModel.LoadingFillBar.DOMoveY(15, 5f));
            loadingBarSequence.AppendInterval(2f);
            loadingBarSequence.AppendCallback(() =>
            {
                Debug.Log("I Am Finished");
            });
        }

        private Tween LoadingBarAnimation()
        {
            return _loadingScreanModel.LoadingFillBar
                .DOSizeDelta(new Vector2(MaxLengthOfBar, _loadingScreanModel.LoadingFillBar.sizeDelta.y), _loadingScreanModel.LoadingBarDuration)
                .SetEase(Ease.InSine)
                .SetRecyclable(true);
        }

        public void Dispose()
        {

        }
    }
}