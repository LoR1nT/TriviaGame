using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.Base;
using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelDataBase.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using Infrastructure.Services.SevicesLocator.Implementation;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Windows.PlayLavelScript
{
    public class PlayLavel : BaseWindows
    {
        [SerializeField] private PlayLavelModel _playLavelModel;
        private PlayLavelControler _playLavelControler;

        public override void Initialize()
        {
            base.Initialize();
            _playLavelControler = new PlayLavelControler(_playLavelModel, ServiceLocator.Container.Single<ILevelGamePlayService>());
            _playLavelControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
        }

        public override void Dispose()
        {
            base.Dispose();
            _playLavelControler.Dispose();
        }
    }
}