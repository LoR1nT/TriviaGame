namespace Infrastructure.Services.StateMachine.States
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}