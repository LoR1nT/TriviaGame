using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;


namespace Assets.Scripts.LoadingScrean
{
    [Serializable]
    public class LoadingScreanModel
    {
        [SerializeField] private RectTransform _loadingFillBarRectTransform;

        public RectTransform LoadingFillBar
        {
            get { return _loadingFillBarRectTransform; }
        }
    }
}
