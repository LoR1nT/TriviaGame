using Infrastructure.Services.Popups.Data;

namespace Infrastructure.Services.Popups.Container
{
    public interface IPopupContainer
    {
        public PopupConfiguration GetPopupConfig(PopupType type);
    }
}