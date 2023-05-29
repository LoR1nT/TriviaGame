using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Popups.PopupSettingsScript
{
    public class PopupSettingsControler
    {
        private PopupSettingsModel _popupSettingsModel;

        public PopupSettingsControler(PopupSettingsModel popupSettingsModel)
        {
            _popupSettingsModel = popupSettingsModel;
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

        private void CheckState()
        {
            
        }

        private void CloseSettings()
        {
            Debug.Log("CloseSettings");
            Dispose();
        }

        private void ChangeLanguage()
        {
            Debug.Log("ChangeLanguage");
        }

        private void ChangeVolumeBackGroundMusic()
        {
            Debug.Log("ChangeVolumeBackGraumdMusic");
        }

        private void ChangeVolumeSoundEffect()
        {
            Debug.Log("ChangeVolumeSoundEffect");
        }


        public void Dispose()
        {
            _popupSettingsModel.CloseButton.onClick.RemoveAllListeners();
            _popupSettingsModel.LanguageChange.onClick.RemoveAllListeners();
        }

    }
}
