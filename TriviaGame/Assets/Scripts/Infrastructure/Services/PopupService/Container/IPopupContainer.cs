using Infrastructure.Services.PopupService.Data;

namespace Infrastructure.Services.PopupService.Container
{
    public interface IPopupContainer
    {
        public PopupConfiguration GetPopupConfig(PopupType type);
    }
}