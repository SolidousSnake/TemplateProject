using _Project.Code.Runtime.Core.StateMachine;
using _Project.Code.Runtime.UI.View.States.Lobby;

namespace _Project.Code.Runtime.Flow.Lobby.States
{
    public class SettingState : IState
    {
        private readonly SettingStateView _stateView;

        public SettingState(SettingStateView stateView)
        {
            _stateView = stateView;
        }

        public void Enter() => _stateView.Open();

        public void Exit() => _stateView.Close();
    }
}