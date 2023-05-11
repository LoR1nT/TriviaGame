using System.Collections.Generic;
using Infrastructure.Services.SevicesLocator.Implementation;
using Infrastructure.Services.StateMachine.Data;
using Infrastructure.Services.StateMachine.States;

namespace Infrastructure.Services.StateMachine.Implementation
{
    public class StateMachine : IStateMachine
    {
        private Dictionary<StateType, IState> _cachedState = null;
        private IState _currentState = null;

        public StateMachine(ServiceLocator serviceLocator)
        {
            _cachedState = new Dictionary<StateType, IState>
            {
                [StateType.InitializationState] = new AppInitializationState(this,serviceLocator),
                [StateType.LoadingState] = new LoadingState(this),
                [StateType.GameState] = new GameState(),
                [StateType.PauseState] = new AppPauseState(),
                [StateType.QuitState] = new AppQuitState(),
            };
        }

        public void ChangeState(StateType newStateType)
        {
            IState newState = GetState(newStateType);

            if (IsInSameState(newState))
                return;
            
            ExitFromCurrentState();
            
            EnterToNewState(newState);
        }

        private bool IsInSameState(IState newState)
        {
            return _currentState == newState;
        }

        private void ExitFromCurrentState()
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }
        }

        private void EnterToNewState(IState newState)
        {
            _currentState = newState;
            _currentState.Enter();
        }

        private IState GetState(StateType newState)
        {
            _cachedState.TryGetValue(newState, out IState state);

            return state;
        }
    }
}