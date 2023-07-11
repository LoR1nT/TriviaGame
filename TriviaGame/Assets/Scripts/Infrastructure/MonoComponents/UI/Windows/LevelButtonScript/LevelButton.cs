using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.EventHolder.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelDataBase.Implementation;
using Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation;
using Infrastructure.Services.SevicesLocator.Implementation;
using Infrastructure.Services.Windows.Implementation;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelButtonScript
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private LevelButtonModel _levelButtonModel;
        private LevelButtonControler _levelButtonControler;

        private void Awake()
        {
            _levelButtonControler = new LevelButtonControler(_levelButtonModel,
                ServiceLocator.Container.Single<IWindowsService>(),
                ServiceLocator.Container.Single<ILevelGamePlayService>(),
                ServiceLocator.Container.Single<IEventHolderService>());
            
        }

        private void Start()
        {
            _levelButtonControler.Initialize();
        }

        public void Data(int level)
        {
            _levelButtonControler.DataTransfer(level);
        }

        private void OnDestroy()
        {
            _levelButtonControler.Dispose();
        }
    }
}