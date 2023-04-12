using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Assets.Scripts.LoadingScrean
{
    public class LoadingScreanControler
    {
        private LoadingScreanModel _loadingScreanModel;
        public const int MaxLengthOfBar = 990;

        public LoadingScreanControler(LoadingScreanModel loadingScreanModel)
        {
            _loadingScreanModel = loadingScreanModel;
        }

        public void Initialize()
        {
            LoadingBarChange();
        }

        private  void LoadingBarChange()
        {
            //while (true)
            //{
            //    _loadingScreanModel.LoadingFillBar.sizeDelta = new Vector2((_loadingScreanModel.LoadingFillBar.sizeDelta.x + 1), _loadingScreanModel.LoadingFillBar.sizeDelta.y);
            //    Thread.Sleep(15);
            //    if (_loadingScreanModel.LoadingFillBar.sizeDelta.x == (MaxLengthOfBar / 3))
            //    {
            //        Thread.Sleep(1000);
            //    }

            //    if (MaxLengthOfBar == _loadingScreanModel.LoadingFillBar.sizeDelta.x)
            //    {
            //        break;
            //    }
            //    Debug.Log("1");
            //}
        }

        public void Dispose()
        {

        }
    }
}