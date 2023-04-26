using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Popups.PopupLostScript
{
    public class PopupLostControler
    {
        private readonly PopupLostModel _popupLostModel;

        public PopupLostControler(PopupLostModel popupLostModel)
        {
            _popupLostModel = popupLostModel;
        }

        public void Initialize()
        {
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            _popupLostModel.BackToMainMenu.onClick.AddListener(BackToMainMenu);
            _popupLostModel.NextAtempt.onClick.AddListener(NextAtempt);
        }

        private void BackToMainMenu()
        {
            Debug.Log("BackToMainMenu");
        }

        private void NextAtempt()
        {
            Debug.Log("NextAtempt");
        }

        public void Dispose()
        {
            _popupLostModel.BackToMainMenu.onClick.RemoveAllListeners();
            _popupLostModel.NextAtempt.onClick.RemoveAllListeners();
        }
    }
}
