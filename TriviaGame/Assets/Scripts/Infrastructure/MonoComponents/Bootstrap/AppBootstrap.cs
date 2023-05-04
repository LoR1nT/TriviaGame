using Infrastructure.Services.StateMachine.Data;
using Infrastructure.Services.StateMachine.Implementation;
using UnityEngine;

namespace Infrastructure.MonoComponents.Bootstrap
{
    public class AppBootstrap : MonoBehaviour
    {
        private IStateMachine _stateMachine = null;
        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            _stateMachine = new StateMachine();
        }

        private void Start()
        {   
            _stateMachine.ChangeState(StateType.InitializationState);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            _stateMachine.ChangeState(StateType.PauseState);
        }

        private void OnApplicationQuit()
        {
            _stateMachine.ChangeState(StateType.QuitState);
        }
    }
}