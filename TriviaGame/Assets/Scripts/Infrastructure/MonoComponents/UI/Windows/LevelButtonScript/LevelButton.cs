using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelButtonScript
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private LevelButtonModel _levelButtonModel;
        private LevelButtonControler _levelButtonControler;

        private void Awake()
        {
            _levelButtonControler = new LevelButtonControler(_levelButtonModel);
        }

        private void Start()
        {
            _levelButtonControler.Initialize();
        }

        private void OnDisable()
        {
            _levelButtonControler.Dispose();
        }
    }
}