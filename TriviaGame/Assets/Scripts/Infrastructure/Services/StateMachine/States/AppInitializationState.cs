using System;
using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation;
using Assets.Scripts.Infrastructure.Services.SceneLoader;
using Assets.Scripts.Infrastructure.Services.SceneLoader.Implementation;
using Infrastructure.MonoComponents.UI.Screens.LoadingScreanScript;
using Infrastructure.MonoComponents.UI.Screens.MainMenuScript;
using Infrastructure.MonoComponents.UI.UIRoot;
using Infrastructure.Services.Popups.Container;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.Screans.Container;
using Infrastructure.Services.Screans.Data;
using Infrastructure.Services.Screans.Implementation;
using Infrastructure.Services.SevicesLocator.Implementation;
using Infrastructure.Services.StateMachine.Data;
using Infrastructure.Services.StateMachine.Implementation;
using Infrastructure.Services.Windows.Container;
using Infrastructure.Services.Windows.Implementation;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            LoadGameScene();
        }

        private void LoadGameScene()
        {
            var sceneLoader = _serviceLocator.Single<ISceneLoaderService>();
            var screenService = _serviceLocator.Single<IScreanService>();

            sceneLoader.LoadScene("Main", LoadSceneMode.Single);
            
            screenService.OpenScrean<LoadingScrean>(ScreanType.LoadingScrean, onScreenClosed: OpenMainMenu);

            _stateMachine.ChangeState(StateType.GameState);
        }

        private void OpenMainMenu()
        {
            var screenService = _serviceLocator.Single<IScreanService>();
            
            screenService.OpenScrean<MainMenu>(ScreanType.MainMenuScrean);
        }

        private void RegisterServices()
        {
            _serviceLocator.Register<ISceneLoaderService>(new SceneLoaderService());
            _serviceLocator.Register<IAssetProvider>(new AssetProvider());
            _serviceLocator.Register<IGameFactory>(new GameFactory());

            CreateUIRoot();
            
            _serviceLocator.Register<IPopupService>(new PopupService(new PopupContainer(), _serviceLocator.Single<IUIRoot>(), _serviceLocator.Single<IAssetProvider>(),_serviceLocator.Single<IGameFactory>()));
            _serviceLocator.Register<IScreanService>(new ScreanService(new ScreanContainer(), _serviceLocator.Single<IUIRoot>(), _serviceLocator.Single<IAssetProvider>(), _serviceLocator.Single<IGameFactory>()));
            _serviceLocator.Register<IWindowsService>(new WindowsService(new WindowsContainer(), _serviceLocator.Single<IUIRoot>(), _serviceLocator.Single<IAssetProvider>(), _serviceLocator.Single<IGameFactory>()));
        }

        private void CreateUIRoot()
        {
            var assetProvider = _serviceLocator.Single<IAssetProvider>();
            var gameFactory = _serviceLocator.Single<IGameFactory>();

            GameObject uiRootObject = assetProvider.GetAsset<GameObject>("UI_Root/UI_Root");
            IUIRoot uiRoot = gameFactory.Create<IUIRoot>(uiRootObject);
            
            _serviceLocator.Register<IUIRoot>(uiRoot);
        }

        public void Exit()
        {
        }
    }
}