using Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.Base;
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
            _levelsScreanControler = new LevelsScreanControler(_levelsScreanModel);
            _levelsScreanControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
        }

        public override void Dispose()
        {
            base.Dispose();
            _levelsScreanControler.Dispose();
        }
    }
}
