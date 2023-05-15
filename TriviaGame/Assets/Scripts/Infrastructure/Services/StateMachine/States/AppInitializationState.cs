using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation;
using Infrastructure.Services.Popups.Container;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.Screans.Container;
using Infrastructure.Services.Screans.Implementation;
using Infrastructure.Services.SevicesLocator.Implementation;
using Infrastructure.Services.StateMachine.Data;
using Infrastructure.Services.StateMachine.Implementation;
using Infrastructure.Services.Windows.Container;
using Infrastructure.Services.Windows.Implementation;

namespace Infrastructure.Services.StateMachine.States
{
    public class AppInitializationState : IState
    {
        private readonly IStateMachine _stateMachine = null;
        private ServiceLocator _serviceLocator = null;

        public AppInitializationState(IStateMachine stateMachine, ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _stateMachine = stateMachine;

            RegisterServices();
        }
        
        public void Enter()
        {
            _stateMachine.ChangeState(StateType.LoadingState);
        }

        private void RegisterServices()
        {
            _serviceLocator.Register<IGameFactory>(new GameFactory());
            _serviceLocator.Register<IAssetProvider>(new AssetProvider());
            _serviceLocator.Register<IPopupService>(new PopupService(new PopupContainer(), null, _serviceLocator.Single<IAssetProvider>(),_serviceLocator.Single<IGameFactory>()));
            _serviceLocator.Register<IScreanService>(new ScreanService(new ScreanContainer(), null, _serviceLocator.Single<IAssetProvider>(), _serviceLocator.Single<IGameFactory>()));
            _serviceLocator.Register<IWindowsService>(new WindowsService(new WindowsContainer(), null, _serviceLocator.Single<IAssetProvider>(), _serviceLocator.Single<IGameFactory>()));
        }

        public void Exit()
        {
        }
    }
}