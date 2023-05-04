using Infrastructure.Services.StateMachine.Data;
using Infrastructure.Services.StateMachine.Implementation;

namespace Infrastructure.Services.StateMachine.States
{
    public class LoadingState : IState
    {
        private readonly IStateMachine _stateMachine = null;

        public LoadingState(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            // Do Something
            
            _stateMachine.ChangeState(StateType.GameState);
        }

        public void Exit()
        {
            
        }
    }
}