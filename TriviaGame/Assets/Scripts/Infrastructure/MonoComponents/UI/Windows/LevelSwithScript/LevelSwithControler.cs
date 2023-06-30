using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelButtonScript;
using Assets.Scripts.Infrastructure.Services.AssetsProvider.Implementation;
using Assets.Scripts.Infrastructure.Services.GameFactorys.Implementation;
using Infrastructure.Services.Windows.Data;
using Infrastructure.Services.Windows.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelSwithScript
{
    public class LevelSwithControler
    {
        private LevelSwithModel _levelSwithModel;
        private IAssetProvider _assetProvider;
        private IGameFactory _gameFactory;
        private string pathToButtonPrefab = "Components/LevelSwithComponent/LevelButton_component/LevelButton_Component";
        private List<LevelButton> _buttons;
        private const int _countOfButtons = 18;


        public LevelSwithControler(LevelSwithModel levelSwithModel, IGameFactory gameFactory, IAssetProvider assetProvider)
        {
            _levelSwithModel = levelSwithModel;
            _gameFactory = gameFactory;
            _assetProvider = assetProvider;
        }

        public void Initialize()
        {
            SpawnLevelButtons();
        }

        private void SpawnLevelButtons()
        {
            GameObject LevelButton = _assetProvider.GetAsset<GameObject>(pathToButtonPrefab);

            if (LevelButton == null)
            {
                Debug.Log("No prefab");
                return;
            }

            _buttons = new List<LevelButton>();
            LevelButton levelButton;

            for (int i = 0; i < _countOfButtons; i++)
            {
                levelButton = _gameFactory.Create<LevelButton>(LevelButton,_levelSwithModel.ParentForButtons);
                _buttons.Add(levelButton);
                TransferDataToButton(levelButton, i);
            }
        }

        private void TransferDataToButton(LevelButton levelButton,int indexOfLevel)
        {
            levelButton.Data(indexOfLevel);
        }


        public void Dispose()
        {

        }
    }
}
