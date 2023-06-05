using Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.Base;
using Infrastructure.Services.Screans.Implementation;
using Infrastructure.Services.SevicesLocator.Implementation;
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
            
            _loadingScreanControler = new LoadingScreanControler(_loadingScreanModel, ServiceLocator.Container.Single<IScreanService>());
            _loadingScreanControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
            
            _loadingScreanControler.Show();
        }

        public override void Dispose()
        {
            base.Dispose();
            
            _loadingScreanControler.Dispose();
        }
    }
}


