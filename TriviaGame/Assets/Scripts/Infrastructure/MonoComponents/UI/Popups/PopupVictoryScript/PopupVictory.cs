using Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.Base;
using Assets.Scripts.Infrastructure.Services.EventHolder.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.Screans.Implementation;
using Infrastructure.Services.SevicesLocator.Implementation;
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

            _popupVictoryControler = new PopupVictoryControler(_popupVictoryModel,
                ServiceLocator.Container.Single<IPopupService>(),
                ServiceLocator.Container.Single<IScreanService>(), 
                ServiceLocator.Container.Single<IEventHolderService>(),
                ServiceLocator.Container.Single<ILevelGamePlayService>());

            _popupVictoryControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
            _popupVictoryControler.OpenPopup();
        }

        public override void Dispose()
        {
            base.Dispose();
            _popupVictoryControler.Dispose();
        }
    }
}