using System;
using UnityEngine;


namespace Assets.Scripts.PopupSettingsScript
{
    public class PopupSettings : MonoBehaviour
    {
        [SerializeField] private PopupSettingsModel _popupSettingsModel;
        private PopupSettingsControler _popupSettingsControler;

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

    }
}