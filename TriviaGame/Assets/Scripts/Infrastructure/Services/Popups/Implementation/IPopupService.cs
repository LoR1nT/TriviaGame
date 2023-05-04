using Infrastructure.Services.Popups.Data;
using Infrastructure.Services.SevicesLocator;

namespace Infrastructure.Services.Popups.Implementation
{
    public interface IPopupService : IService
    {
        public bool HasAnyPopupsOpened { get; }
        public void OpenPopup(PopupType type);
        public void ClosePopup(PopupType type);
        public void ClosePopupOnTop();
    }
}