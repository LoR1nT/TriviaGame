using System.Collections.Generic;
using Infrastructure.Services.PopupService.Data;

namespace Infrastructure.Services.PopupService.Container
{
    public class PopupContainer : IPopupContainer
    {
        private readonly Dictionary<PopupType, PopupConfiguration> _popupContainer = null;

        public PopupContainer()
        {
            _popupContainer = new Dictionary<PopupType, PopupConfiguration>
            {
                [PopupType.SettingsPopup] = new PopupConfiguration("Setting Popup", "Popups/PopupSettings/Popup_settings"),
            };
        }

        public PopupConfiguration GetPopupConfig(PopupType type)
        {
            if (!_popupContainer.ContainsKey(type))
            {
                return null;
            }
            else
            {
                return _popupContainer[type];
            }
        }
    }
}