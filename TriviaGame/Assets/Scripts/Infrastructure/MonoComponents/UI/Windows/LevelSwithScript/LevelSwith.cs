using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.Base;
using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation;
using Infrastructure.Services.SevicesLocator.Implementation;
using Infrastructure.Services.Windows.Implementation;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelSwithScript
{
    public class LevelSwith : BaseWindows
    {
        [SerializeField] private LevelSwithModel _levelSwithModel;
        private LevelSwithControler _levelSwithControler;

        public override void Initialize()
        {
            base.Initialize();
            _levelSwithControler = new LevelSwithControler(_levelSwithModel, ServiceLocator.Container.Single<IGameFactory>(), ServiceLocator.Container.Single<IAssetProvider>());
            _levelSwithControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
        }

        public override void Dispose()
        {
            base.Dispose();
            _levelSwithControler.Dispose();
        }

    }
}