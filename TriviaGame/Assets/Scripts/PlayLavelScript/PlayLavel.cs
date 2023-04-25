using UnityEngine;

namespace Assets.Scripts.PlayLavelScript
{
    public class PlayLavel : MonoBehaviour
    {
        [SerializeField] private PlayLavelModel _playLavelModel;
        private PlayLavelControler _playLavelControler;

        private void Awake()
        {
            _playLavelControler = new PlayLavelControler(_playLavelModel);
        }

        private void Start()
        {
            _playLavelControler.Initialize();
        }

        private void OnDisable()
        {
            _playLavelControler.Dispose();
        }
    }
}