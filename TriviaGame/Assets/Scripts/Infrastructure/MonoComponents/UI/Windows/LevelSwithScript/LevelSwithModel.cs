using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.LevelSwithScript
{
    [Serializable]
    public class LevelSwithModel
    {
        [SerializeField] private Transform _parentForButtons;

        public Transform ParentForButtons { get { return _parentForButtons; } }

    }
}