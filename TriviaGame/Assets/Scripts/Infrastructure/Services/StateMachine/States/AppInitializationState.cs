using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.EventHolder.Implementation;
using Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelDataBase.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
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
        private const string MAIN_SCENE_NAME = "Main";
        private const string UI_ROOT_PATH = "UI_Root/UI_Root";
        private readonly IStateMachine _stateMachine = null;
        private ServiceLocator _serviceLocator = null;
        
        private IUIRoot _uiRoot = null;
        private ISceneLoaderService _sceneLoaderService = null;
        private IAssetProvider _assetProvider = null;
        private IGameFactory _gameFactory = null;
        private IScreanService _screanService = null;
        private ILevelDataBaseService _levelDataBaseService = null;
        private IWindowsService _windowsService = null;
        private IPopupService _popupService = null;
        private IEventHolderService _eventHolderService = null;

        public AppInitializationState(IStateMachine stateMachine, ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            RegisterServices();

            CreateUIRoot();

            RegisterUI();
            
            LoadGameScene();
        }

        private void LoadGameScene()
        {
            _sceneLoaderService.LoadScene(MAIN_SCENE_NAME, LoadSceneMode.Single);
            
            _screanService.OpenScrean<LoadingScrean>(ScreanType.LoadingScrean, onScreenClosed: OpenMainMenu);

            _stateMachine.ChangeState(StateType.GameState);
        }

        private void OpenMainMenu()
        {
            _screanService.OpenScrean<MainMenu>(ScreanType.MainMenuScrean);
        }

        private void RegisterServices()
        {
            _sceneLoaderService = _serviceLocator.Register<ISceneLoaderService>(new SceneLoaderService());
            _assetProvider = _serviceLocator.Register<IAssetProvider>(new AssetProvider());
            _gameFactory = _serviceLocator.Register<IGameFactory>(new GameFactory());

        }

        private void CreateUIRoot()
        {
            GameObject uiRootObject = _assetProvider.GetAsset<GameObject>(UI_ROOT_PATH);
            _uiRoot = _gameFactory.Create<IUIRoot>(uiRootObject);
        }

        private void RegisterUI()
        {
            _serviceLocator.Register<IUIRoot>(_uiRoot);

            _popupService = _serviceLocator.Register<IPopupService>(new PopupService(new PopupContainer(), _uiRoot, _assetProvider,_gameFactory));
            _screanService = _serviceLocator.Register<IScreanService>(new ScreanService(new ScreanContainer(), _uiRoot, _assetProvider, _gameFactory));
            _windowsService = _serviceLocator.Register<IWindowsService>(new WindowsService(new WindowsContainer(), _uiRoot, _assetProvider, _gameFactory));
            _eventHolderService = _serviceLocator.Register<IEventHolderService>(new EventHolderService());
            _levelDataBaseService = _serviceLocator.Register<ILevelDataBaseService>(new LevelDataBaseService(_assetProvider));
            _serviceLocator.Register<ILevelGamePlayService>(new LevelGamePlayService(_windowsService, _popupService, _levelDataBaseService, _eventHolderService));
        }

        public void Exit()
        {
        }
    }
}