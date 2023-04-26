using System;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Screens.LoadingScreanScript
{
    [Serializable]
    public class LoadingScreanModel
    {
        [SerializeField] private RectTransform _loadingFillBarRectTransform;
        [SerializeField] private float _loadingBarDuration = 4f;

        public RectTransform LoadingFillBar
        {
            get { return _loadingFillBarRectTransform; }
        }

        public float LoadingBarDuration
        {
            get { return _loadingBarDuration; }
        }
    }
}
