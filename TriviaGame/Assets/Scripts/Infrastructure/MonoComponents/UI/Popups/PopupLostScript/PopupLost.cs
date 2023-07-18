using Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.Base;
using Assets.Scripts.Infrastructure.Services.EventHolder.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.Screans.Implementation;
using Infrastructure.Services.SevicesLocator.Implementation;
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

            _popupLostControler = new PopupLostControler(_popupLostModel,
                ServiceLocator.Container.Single<IPopupService>(),
                ServiceLocator.Container.Single<IScreanService>(),
                ServiceLocator.Container.Single<IEventHolderService>(),
                ServiceLocator.Container.Single<ILevelGamePlayService>());
            
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