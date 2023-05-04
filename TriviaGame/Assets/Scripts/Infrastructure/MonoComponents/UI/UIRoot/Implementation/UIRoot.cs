using System;
using Infrastructure.MonoComponents.UI.UIRoot.Data;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.UIRoot.Implementation
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        [Header("Screens")]
        [SerializeField] private RectTransform _screensRoot = null;
        
        [Header("Windows")]
        [SerializeField] private RectTransform _windowsRoot = null;

        [Header("Popups")]
        [SerializeField] private RectTransform _popupsRoot = null;
        
        public RectTransform GetUIRoot(UIRootType type)
        {
            switch (type)
            {
                case UIRootType.ScreensRoot:
                    return _screensRoot;
                case UIRootType.WindowsRoot:
                    return _windowsRoot;
                case UIRootType.PopupsRoot:
                    return _popupsRoot;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}