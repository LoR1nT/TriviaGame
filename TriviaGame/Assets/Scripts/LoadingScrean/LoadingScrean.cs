using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LoadingScrean
{
    public class LoadingScrean : MonoBehaviour
    {
        [SerializeField] private LoadingScreanModel _loadingScreanModel;
        private LoadingScreanControler _loadingScreanControler;

        private void Awake()
        {
            _loadingScreanControler = new LoadingScreanControler(_loadingScreanModel);
        }

        private void Start()
        {
            _loadingScreanControler.Initialize();
        }

        private void OnDisable()
        {
            _loadingScreanControler.Dispose();
        }
    }
}


