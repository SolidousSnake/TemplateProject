using _Project.Code.Runtime.Core.StateMachine;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.UI.View.States.Level;
using UnityEngine;

namespace _Project.Code.Runtime.Flow.Gameplay.States
{
    public class PlayingState : IState
    {
        private readonly PlayingStateView _stateView;

        public PlayingState(PlayingStateView stateView)
        {
            _stateView = stateView;
        }

        public void Enter()
        {
            _stateView.Open();
            Time.timeScale = Constants.Time.ResumedValue;
        }

        public void Exit() => _stateView.Close();
    }
}