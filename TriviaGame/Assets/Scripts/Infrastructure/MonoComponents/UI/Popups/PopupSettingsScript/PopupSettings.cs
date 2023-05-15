using Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.Base;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Popups.PopupSettingsScript
{
    public class PopupSettings : BasePopup
    {
        [SerializeField] private PopupSettingsModel _popupSettingsModel;
        private PopupSettingsControler _popupSettingsControler;

        public override void Initialize()
        {
            base.Initialize();
            
            _popupSettingsControler = new PopupSettingsControler(_popupSettingsModel);
            
            _popupSettingsControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
            
            _popupSettingsControler.UpdateData();
        }

        public override void Dispose()
        {
            base.Dispose();
            
            _popupSettingsControler.Dispose();
        }


        /*
        private void Awake()
        {
            _popupSettingsControler = new PopupSettingsControler(_popupSettingsModel);
        }

        private void Start()
        {
            _popupSettingsControler.Initialize();
            
        }

        private void OnDisable()
        {
            _popupSettingsControler.Dispose();
        }
        */

    }
}