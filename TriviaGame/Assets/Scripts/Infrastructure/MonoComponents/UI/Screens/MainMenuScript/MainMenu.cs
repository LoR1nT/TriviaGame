using Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.Base;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.Screans.Implementation;
using Infrastructure.Services.SevicesLocator.Implementation;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Screens.MainMenuScript
{
    public class MainMenu : BaseScreen
    {
        [SerializeField] private MainMenuModel _mainMenuModel;
        private MainMenuControler _mainMenuControler;

        public override void Initialize()
        {
            base.Initialize();
            _mainMenuControler = new MainMenuControler(_mainMenuModel, ServiceLocator.Container.Single<IScreanService>(),ServiceLocator.Container.Single<IPopupService>());
            _mainMenuControler.Initialize();
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