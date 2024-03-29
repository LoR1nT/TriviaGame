using System.Collections.Generic;
using Infrastructure.Services.Popups.Data;

namespace Infrastructure.Services.Popups.Container
{
    public class PopupContainer : IPopupContainer
    {
        private readonly Dictionary<PopupType, PopupConfiguration> _popupContainer = null;

        public PopupContainer()
        {
            _popupContainer = new Dictionary<PopupType, PopupConfiguration>
            {
                [PopupType.SettingsPopup] = new PopupConfiguration("Setting Popup", "Popups/PopupSettings/Popup_settings"),
                [PopupType.VicrotyPopup] = new PopupConfiguration("Victory Popup", "Popups/PopupVictory/Popup_Victory"),
                [PopupType.LostPopup] = new PopupConfiguration("Lost Popup", "Popups/PopupLost/Popup_Lost"),
                [PopupType.NextQuestionPopup] = new PopupConfiguration("NextQuestion Popup", "Popups/PopupNextQuestion/Popup_nextQuestion"),
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