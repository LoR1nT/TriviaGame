using Assets.Scripts.Infrastructure;
using Infrastructure.Services.StateMachine.Data;
using UnityEngine;

namespace Infrastructure.MonoComponents.Bootstrap
{
    public class AppBootstrap : MonoBehaviour
    {
        private Game _game = null;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            _game = new Game();
        }

        private void Start()
        {
            _game.StateMachine.ChangeState(StateType.InitializationState);
        }
    }
}