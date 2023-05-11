using Infrastructure.Services.SevicesLocator.Implementation;
using Infrastructure.Services.StateMachine.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure
{
    public class Game
    {
        private IStateMachine _stateMachine = null;

        public IStateMachine StateMachine{ get {return _stateMachine;} }

        public Game()
        {
            _stateMachine = new StateMachine(ServiceLocator.Container);
        }
    }
}
