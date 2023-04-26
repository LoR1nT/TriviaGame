using UnityEngine;

namespace Infrastructure.MonoComponents.UI.Screens.LoadingScreanScript
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


