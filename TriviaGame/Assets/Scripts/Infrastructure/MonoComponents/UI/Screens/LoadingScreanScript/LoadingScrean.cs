using Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.Base;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Screens.LoadingScreanScript
{
    public class LoadingScrean : BaseScreen
    {
        [SerializeField] private LoadingScreanModel _loadingScreanModel;
        private LoadingScreanControler _loadingScreanControler;

        public override void Initialize()
        {
            base.Initialize();
            _loadingScreanControler = new LoadingScreanControler(_loadingScreanModel);
            _loadingScreanControler.Initialize();
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


