using _Project.Code.Runtime.Core.StateMachine;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.UI.View.States.Level;
using UnityEngine;

namespace _Project.Code.Runtime.Flow.Gameplay.States
{
    public class PauseState : IState
    {
        private readonly PauseStateView _stateView;

        public PauseState(PauseStateView stateView)
        {
            _stateView = stateView;
        }

        public void Enter()
        {
            _stateView.gameObject.SetActive(true);
            Time.timeScale = Constants.Time.PausedValue;
        }

        public void Exit()
        {
            Time.timeScale = Constants.Time.ResumedValue;
            _stateView.gameObject.SetActive(false);
        }
    }
}