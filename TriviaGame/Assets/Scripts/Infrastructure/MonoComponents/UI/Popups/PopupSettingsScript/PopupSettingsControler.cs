using Infrastructure.Services.Popups.Data;
using Infrastructure.Services.Popups.Implementation;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Popups.PopupSettingsScript
{
    public class PopupSettingsControler
    {
        private PopupSettingsModel _popupSettingsModel;
        private IPopupService _popupService;

        public PopupSettingsControler(PopupSettingsModel popupSettingsModel,IPopupService popupService)
        {
            _popupSettingsModel = popupSettingsModel;
            _popupService = popupService;
        }

        public void Initialize()
        {
            InitializeButtons();
        }

        public void UpdateData()
        {

        }

        private void InitializeButtons()
        {
            _popupSettingsModel.CloseButton.onClick.AddListener(CloseSettings);
            _popupSettingsModel.LanguageChange.onClick.AddListener(ChangeLanguage);
        }


        private void CloseSettings()
        {
            Debug.Log("CloseSettings");
            _popupService.ClosePopup(PopupType.SettingsPopup);
            Dispose();
        }

        private void ChangeLanguage()
        {
            Debug.Log("ChangeLanguage");
            
        }

        private void ChangeVolumeBackGroundMusic()
        {
            Debug.Log("ChangeVolumeBackGraumdMusic to " + (_popupSettingsModel.BGMSlider.value*100) + "%");
        }

        private void ChangeVolumeSoundEffect()
        {
            Debug.Log("ChangeVolumeSoundEffect" + (_popupSettingsModel.SoundEffectSlider.value*100) + "%");
        }


        public void Dispose()
        {
            _popupSettingsModel.CloseButton.onClick.RemoveAllListeners();
            _popupSettingsModel.LanguageChange.onClick.RemoveAllListeners();
        }

    }
}
