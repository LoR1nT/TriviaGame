using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Windows.LevelSwithScript
{
    public class LevelSwith : MonoBehaviour
    {
        [SerializeField] private LevelSwithModel _levelSwithModel;
        private LevelSwithControler _levelSwithControler;

        private void Awake()
        {
            _levelSwithControler = new LevelSwithControler(_levelSwithModel);
        }

        private void Start()
        {
            _levelSwithControler.Initialize();
        }

        private void OnDisable()
        {
            _levelSwithControler.Dispose();
        }

    }
}