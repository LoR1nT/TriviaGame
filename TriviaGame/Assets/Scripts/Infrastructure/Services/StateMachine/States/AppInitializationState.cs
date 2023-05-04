using Infrastructure.Services.Popups.Container;
using Infrastructure.Services.Popups.Implementation;
using Infrastructure.Services.SevicesLocator.Implementation;
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
            RegisterServices();
            
            _stateMachine.ChangeState(StateType.LoadingState);
        }

        private void RegisterServices()
        {
            ServiceLocator.Container.Register<IPopupService>(new PopupService(new PopupContainer(), null));
        }

        public void Exit()
        {
        }
    }
}