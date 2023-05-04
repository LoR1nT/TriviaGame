using Infrastructure.Services.StateMachine.Data;
using Infrastructure.Services.StateMachine.Implementation;

namespace Infrastructure.Services.StateMachine.States
{
    public class AppInitializationState : IState
    {
        private readonly IStateMachine _stateMachine = null;

        public AppInitializationState(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            // Do Something
            
            _stateMachine.ChangeState(StateType.LoadingState);
        }

        public void Exit()
        {
        }
    }
}