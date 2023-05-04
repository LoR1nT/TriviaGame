using Infrastructure.Services.StateMachine.Data;

namespace Infrastructure.Services.StateMachine.Implementation
{
    public interface IStateMachine
    {
        void ChangeState(StateType newStateType);
    }
}