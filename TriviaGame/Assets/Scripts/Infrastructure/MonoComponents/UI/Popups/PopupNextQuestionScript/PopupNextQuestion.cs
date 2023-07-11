using Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.Base;
using Assets.Scripts.Infrastructure.Services.EventHolder.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using Infrastructure.MonoComponents.UI.Popups.PopupVictoryScript;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.Screans.Implementation;
using Infrastructure.Services.SevicesLocator.Implementation;
using Infrastructure.Services.Windows.Implementation;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.PopupNextQuestionScript
{
    public class PopupNextQuestion : BasePopup
    {
        [SerializeField] private PopupNextQuestionModel _popupNextQuestionModel;
        private PopupNextQuestionControler _popupNextQuestionControler;

        public override void Initialize()
        {
            base.Initialize();
            _popupNextQuestionControler = new PopupNextQuestionControler(_popupNextQuestionModel,
                ServiceLocator.Container.Single<ILevelGamePlayService>(),
                ServiceLocator.Container.Single<IPopupService>(),
                ServiceLocator.Container.Single<IScreanService>(),
                ServiceLocator.Container.Single<IEventHolderService>());

            _popupNextQuestionControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
        }

        public override void Dispose()
        {
            base.Dispose();
            _popupNextQuestionControler.Dispose();
        }
    }
}