namespace _Project.Code.Runtime.UI.View.States.Lobby.Behaviour
{
    public class ToggleBehaviour : BaseStateViewBehaviour
    {
        public override void Open() => gameObject.SetActive(true);
        public override void Close() =>  gameObject.SetActive(false);
    }
}