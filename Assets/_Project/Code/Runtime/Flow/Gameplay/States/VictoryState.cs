using _Project.Code.Runtime.Core.StateMachine;
using _Project.Code.Runtime.UI.View.States.Level;

namespace _Project.Code.Runtime.Flow.Gameplay.States
{
    public class VictoryState : IState
    {
        private readonly VictoryStateView _stateView;
        
        
        
        public void Enter()
        {
            _stateView.Open();
        }

        public void Exit()
        {
            _stateView.Close();
        }
    }
}