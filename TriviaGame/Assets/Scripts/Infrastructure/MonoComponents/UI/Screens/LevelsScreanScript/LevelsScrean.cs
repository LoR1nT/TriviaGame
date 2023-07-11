using Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.Base;
using Assets.Scripts.Infrastructure.Services.EventHolder.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using Infrastructure.Services.Screans.Implementation;
using Infrastructure.Services.SevicesLocator.Implementation;
using Infrastructure.Services.Windows.Implementation;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.LevelsScreanScript
{
    public class LevelsScrean : BaseScreen
    {
        [SerializeField] private LevelsScreanModel _levelsScreanModel;
        private LevelsScreanControler _levelsScreanControler;

        public override void Initialize()
        {
            base.Initialize();
            _levelsScreanControler = new LevelsScreanControler(_levelsScreanModel,
                ServiceLocator.Container.Single<IScreanService>(),
                ServiceLocator.Container.Single<IWindowsService>(),
                ServiceLocator.Container.Single<ILevelGamePlayService>(),
                ServiceLocator.Container.Single<IEventHolderService>());
            _levelsScreanControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
            _levelsScreanControler.OpenScreen();
        }

        public override void Dispose()
        {
            base.Dispose();
            _levelsScreanControler.Dispose();
        }

    }
}
