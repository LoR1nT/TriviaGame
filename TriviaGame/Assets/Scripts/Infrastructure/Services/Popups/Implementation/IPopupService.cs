using Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.Base;
using Infrastructure.Services.Popups.Data;
using Infrastructure.Services.SevicesLocator;

namespace Infrastructure.Services.Popups.Implementation
{
    public interface IPopupService : IService
    {
        public bool HasAnyPopupsOpened { get; }
        public void OpenPopup<TPopup>(PopupType type) where TPopup : BasePopup;
        public void ClosePopup(PopupType type);
        public void ClosePopupOnTop();
    }
}