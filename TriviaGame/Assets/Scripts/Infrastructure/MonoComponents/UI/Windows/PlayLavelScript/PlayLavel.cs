using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.Base;
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
            _playLavelControler = new PlayLavelControler(_playLavelModel);
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