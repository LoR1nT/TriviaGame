using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Popups.PopupSettingsScript
{
    public class PopupSettingsControler
    {
        private PopupSettingsModel _popupSettingsModel;
        //private readonly int _maxLengOfBar = 248;

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
            _popupSettingsModel.BGMButton.onClick.AddListener(ChangeVolumeBackGroundMusic);
            _popupSettingsModel.SoundEffectButton.onClick.AddListener(ChangeVolumeSoundEffect);

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
            _popupSettingsModel.PopUpSettings.SetActive(false);
            _popupSettingsModel.CloseButton.onClick.RemoveAllListeners();
            _popupSettingsModel.BGMButton.onClick.RemoveAllListeners();
            _popupSettingsModel.SoundEffectButton.onClick.RemoveAllListeners();
            _popupSettingsModel.LanguageChange.onClick.RemoveAllListeners();
        }

    }
}
