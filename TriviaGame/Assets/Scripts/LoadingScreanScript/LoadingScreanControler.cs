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
            loadingBarSequence.SetRecyclable(true);
            loadingBarSequence.AppendInterval(1f);
            loadingBarSequence.Append(LoadingBarAnimation());;
            loadingBarSequence.AppendInterval(1f);
            loadingBarSequence.AppendCallback(() =>
            {
                Debug.Log("Loading Finished");
            });
        }

        private Tween LoadingBarAnimation()
        {
            return _loadingScreanModel.LoadingFillBar
                .DOSizeDelta(new Vector2(MaxLengthOfBar, _loadingScreanModel.LoadingFillBar.sizeDelta.y), _loadingScreanModel.LoadingBarDuration)
                .SetEase(Ease.InOutCubic)
                .SetRecyclable(true);
        }

        public void Dispose()
        {

        }
    }
}