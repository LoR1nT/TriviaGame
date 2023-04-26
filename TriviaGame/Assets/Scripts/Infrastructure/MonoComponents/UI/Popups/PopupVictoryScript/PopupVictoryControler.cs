using DG.Tweening;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Popups.PopupVictoryScript
{
    public class PopupVictoryControler
    {
        private readonly PopupVictoryModel _popupVictoryModel;
        private readonly int _amountOfStarsReached = 3;

        public PopupVictoryControler(PopupVictoryModel popupVictoryModel)
        {
            _popupVictoryModel = popupVictoryModel;
        }

        public void Initialize()
        {
            InitializeButtons();
            AmountOfStarsReached();
        }

        private void InitializeButtons()
        {
            _popupVictoryModel.NextLavelButton.onClick.AddListener(GoToNextLavel);
            _popupVictoryModel.BackToMainMenuButton.onClick.AddListener(GoToMainMenu);
        }

        private void GoToNextLavel()
        {
            Debug.Log("GoToNextLavel");
        }

        private void GoToMainMenu()
        {
            Debug.Log("GoToMainMenu");
        }

        private void AmountOfStarsReached()
        {
            Sequence loadingBarSequence = DOTween.Sequence();
            loadingBarSequence.SetRecyclable(true);
            loadingBarSequence.AppendInterval(0.5f);
            switch (_amountOfStarsReached)
            {
                case 1:
                    loadingBarSequence.Append(StarLeft()); ;
                    loadingBarSequence.AppendInterval(0.1f);
                    break;
                case 2:
                    loadingBarSequence.Append(StarLeft()); ;
                    loadingBarSequence.AppendInterval(0.1f);
                    loadingBarSequence.Append(StarCenter()); ;
                    loadingBarSequence.AppendInterval(0.1f);
                    break;
                case 3:
                    loadingBarSequence.Append(StarLeft()); ;
                    loadingBarSequence.AppendInterval(0.1f);
                    loadingBarSequence.Append(StarCenter()); ;
                    loadingBarSequence.AppendInterval(0.1f);
                    loadingBarSequence.Append(StarRight()); ;
                    loadingBarSequence.AppendInterval(0.1f);
                    break;
            }
            
            loadingBarSequence.AppendCallback(() =>
            {
                Debug.Log("Loading Finished");
            });
        }
        private Tween StarLeft()
        {
            return _popupVictoryModel.StarLeft1
                .DOScale(new Vector2(1.0f, 1.0f), 0.3f)
                .SetEase(Ease.Linear)
                .SetRecyclable(true);
        }
        private Tween StarCenter()
        {
            return _popupVictoryModel.StarCenter1
                .DOScale(new Vector2(1.0f,1.0f), 0.3f)
                .SetEase(Ease.Linear)
                .SetRecyclable(true);
        }
        private Tween StarRight()
        {
            return _popupVictoryModel.StarRight1
                .DOScale(new Vector2(1.0f, 1.0f), 0.3f)
                .SetEase(Ease.Linear)
                .SetRecyclable(true);
        }


        public void Dispose()
        {
            _popupVictoryModel.NextLavelButton.onClick.RemoveAllListeners();
            _popupVictoryModel.BackToMainMenuButton.onClick.RemoveAllListeners();
        }
    }
}
