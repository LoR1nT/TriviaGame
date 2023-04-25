using System;
using UnityEngine;

namespace Assets.Scripts.PopupVictoryScript
{
    public class PopupVictory : MonoBehaviour
    {
        [SerializeField] private PopupVictoryModel _popupVictoryModel;
        private PopupVictoryControler _popupVictoryControler;

        private void Awake()
        {
            _popupVictoryControler = new PopupVictoryControler(_popupVictoryModel);
        }

        private void Start()
        {
            _popupVictoryControler.Initialize();
        }

        private void OnDisable()
        {
            _popupVictoryControler.Dispose();
        }
    }
}