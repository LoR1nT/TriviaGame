using Infrastructure.MonoComponents.UI.UIRoot.Data;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.UIRoot
{
    public interface IUIRoot
    {
        public RectTransform GetUIRoot(UIRootType type);
    }
}