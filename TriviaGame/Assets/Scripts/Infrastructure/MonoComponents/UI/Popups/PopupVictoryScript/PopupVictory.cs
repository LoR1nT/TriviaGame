using Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.Base;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Popups.PopupVictoryScript
{
    public class PopupVictory : BasePopup
    {
        [SerializeField] private PopupVictoryModel _popupVictoryModel;
        private PopupVictoryControler _popupVictoryControler;

        public override void Initialize()
        {
            base.Initialize();

            _popupVictoryControler = new PopupVictoryControler(_popupVictoryModel);

            _popupVictoryControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
        }

        public override void Dispose()
        {
            base.Dispose();
            _popupVictoryControler.Dispose();
        }
    }
}