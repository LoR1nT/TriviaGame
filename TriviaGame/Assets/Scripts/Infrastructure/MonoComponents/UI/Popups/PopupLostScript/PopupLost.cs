using Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.Base;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Popups.PopupLostScript
{
    public class PopupLost : BasePopup
    {
        [SerializeField] private PopupLostModel _popupLostModel;
        private PopupLostControler _popupLostControler;

        public override void Initialize()
        {
            base.Initialize();

            _popupLostControler = new PopupLostControler(_popupLostModel);
            
            _popupLostControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}