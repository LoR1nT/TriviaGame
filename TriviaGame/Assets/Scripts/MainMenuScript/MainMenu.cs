using System;
using UnityEngine;


namespace Assets.Scripts.MainMenuScript
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private MainMenuModel _mainMenuModel;
        private MainMenuControler _mainMenuControler;

        private void Awake()
        {
            _mainMenuControler = new MainMenuControler(_mainMenuModel);
        }

        private void Start()
        {
            _mainMenuControler.Initialize();
        }

        private void OnDisable()
        {
            _mainMenuControler.Dispose();
        }

    }
}