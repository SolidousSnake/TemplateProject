using _Project.Code.Runtime.Core.Factory;
using _Project.Code.Runtime.Core.StateMachine;
using _Project.Code.Runtime.Flow.Lobby.States;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.Runtime.Core.Bootstrapper
{
    public class LobbyBootstrapper : IInitializable
    {
        [Inject] private readonly StateFactory _stateFactory;
        [Inject] private readonly LobbyStateMachine _fsm;

        public async void Initialize()
        {
#if UNITY_EDITOR
            // Required for the correct operation of BootFromAnyScene, since the editor executes after the container build
            await UniTask.Yield();
#endif
            CreateStates();
            _fsm.Enter<HubState>();
        }


        private void CreateStates()
        {
            _fsm.RegisterState(_stateFactory.Create<HubState>());
            _fsm.RegisterState(_stateFactory.Create<SettingState>());
            _fsm.RegisterState(_stateFactory.Create<SelectLevelState>());
            _fsm.RegisterState(_stateFactory.Create<ShopState>());
        }
    }
}