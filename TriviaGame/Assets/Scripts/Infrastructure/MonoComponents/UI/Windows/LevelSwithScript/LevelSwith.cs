using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.Base;
using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Windows.LevelSwithScript
{
    public class LevelSwith : BaseWindows
    {
        [SerializeField] private LevelSwithModel _levelSwithModel;
        private LevelSwithControler _levelSwithControler;

        public override void Initialize()
        {
            base.Initialize();
            _levelSwithControler = new LevelSwithControler(_levelSwithModel);
            _levelSwithControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
        }

        public override void Dispose()
        {
            base.Dispose();
            _levelSwithControler.Dispose();
        }

        //private void Awake()
        //{
        //    _levelSwithControler = new LevelSwithControler(_levelSwithModel);
        //}

        //private void Start()
        //{
        //    _levelSwithControler.Initialize();
        //}

        //private void OnDisable()
        //{
        //    _levelSwithControler.Dispose();
        //}

    }
}