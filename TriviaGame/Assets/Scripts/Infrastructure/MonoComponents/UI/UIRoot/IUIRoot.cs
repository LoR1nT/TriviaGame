using Infrastructure.MonoComponents.UI.UIRoot.Data;
using Infrastructure.Services.SevicesLocator;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.UIRoot
{
    public interface IUIRoot : IService
    {
        public RectTransform GetUIRoot(UIRootType type);
    }
}