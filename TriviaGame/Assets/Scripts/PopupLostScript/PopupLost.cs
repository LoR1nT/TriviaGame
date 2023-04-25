using System;
using UnityEngine;

namespace Assets.Scripts.PopupLostScript
{
    public class PopupLost : MonoBehaviour
    {
        [SerializeField] private PopupLostModel _popupLostModel;
        private PopupLostControler _popupLostControler;

        private void Awake()
        {
            _popupLostControler = new PopupLostControler(_popupLostModel);
        }

        private void Start()
        {
            _popupLostControler.Initialize();
        }

        private void OnDisable()
        {
            _popupLostControler.Dispose();
        }

    }
}