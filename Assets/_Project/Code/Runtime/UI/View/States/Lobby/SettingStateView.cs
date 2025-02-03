using _Project.Code.Runtime.UI.View.States.Lobby.Behaviour;
using UnityEngine;

namespace _Project.Code.Runtime.UI.View.States.Lobby
{
    [RequireComponent(typeof(BaseStateViewBehaviour))]
    public class SettingStateView : MonoBehaviour
    {
        [SerializeField] private BaseStateViewBehaviour _behaviour;

        public void Open() => _behaviour.Open();
        public void Close() => _behaviour.Close();
    }
}