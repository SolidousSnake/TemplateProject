using _Project.Code.Runtime.Core.StateMachine;
using _Project.Code.Runtime.UI.View.States.Lobby;

namespace _Project.Code.Runtime.Flow.Lobby.States
{
    public class HubState : IState
    {
        private readonly HubStateView _stateView;

        public HubState(HubStateView stateView)
        {
            _stateView = stateView;
        }

        public void Enter() => _stateView.Open();

        public void Exit() => _stateView.Close();
    }
}