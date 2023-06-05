using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelButtonScript
{
    public class LevelButton : BaseWindows
    {
        [SerializeField] private LevelButtonModel _levelButtonModel;
        private LevelButtonControler _levelButtonControler;

        public override void Initialize()
        {
            base.Initialize();
            _levelButtonControler = new LevelButtonControler(_levelButtonModel);
            _levelButtonControler.Initialize();
        }

        public override void Open()
        {
            base.Open();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}