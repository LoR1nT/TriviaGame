using DG.Tweening;
using Infrastructure.Services.Screans.Data;
using Infrastructure.Services.Screans.Implementation;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

namespace Infrastructure.MonoComponents.UI.Screens.LoadingScreanScript
{
    public class LoadingScreanControler
    {
        public const int MaxLengthOfBar = 990;
        private LoadingScreanModel _loadingScreanModel;
        private readonly IScreanService _screanService = null;
        private Sequence _loadingBarSequence = null;

        public LoadingScreanControler(LoadingScreanModel loadingScreanModel, IScreanService screanService)
        {
            _loadingScreanModel = loadingScreanModel;
            _screanService = screanService;
        }

        public void Initialize()
        {
            CreateLoadingSequence();
        }

        public void Show()
        {
            _loadingBarSequence.Play();
        }

        private void CreateLoadingSequence()
        {
            _loadingBarSequence = DOTween.Sequence();
            _loadingBarSequence.SetRecyclable(true);
            _loadingBarSequence.Append(LoadingBarAnimation());;
            _loadingBarSequence.AppendInterval(1f);
            _loadingBarSequence.AppendCallback(() =>
            {
                CloseScreen();
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

        private void CloseScreen()
        {
            _screanService.CloseScrean(ScreanType.LoadingScrean);
        }

        public void Dispose()
        {
            _loadingBarSequence.Kill();
        }
    }
}