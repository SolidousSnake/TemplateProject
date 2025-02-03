using _Project.Code.Runtime.Core.StateMachine;
using UnityEngine;

namespace _Project.Code.Runtime.Flow.Lobby.States
{
    public class QuitGameState : IState
    {
        public void Enter()
        {
            Application.Quit();
        }

        public void Exit()
        {
        }
    }
}