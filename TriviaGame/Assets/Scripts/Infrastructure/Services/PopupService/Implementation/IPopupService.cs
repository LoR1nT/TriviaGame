using Infrastructure.Services.PopupService.Data;

namespace Infrastructure.Services.PopupService.Implementation
{
    public interface IPopupService
    {
        public bool HasAnyPopupsOpened { get; }
        public void OpenPopup(PopupType type);
        public void ClosePopup(PopupType type);
        public void ClosePopupOnTop();
    }
}