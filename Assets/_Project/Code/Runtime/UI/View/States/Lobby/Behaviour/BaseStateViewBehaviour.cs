using UnityEngine;

namespace _Project.Code.Runtime.UI.View.States.Lobby.Behaviour
{
    public abstract class BaseStateViewBehaviour : MonoBehaviour
    {
        public abstract void Open();
        public abstract void Close();
    }
}