using _Project.Code.Runtime.Core.Factory;
using _Project.Code.Runtime.Core.StateMachine;
using _Project.Code.Runtime.Flow.Gameplay.States;
using _Project.Code.Runtime.Services.LevelSelection;
using _Project.Code.Runtime.Services.Log;
using _Project.Code.Runtime.Services.SaveLoad;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.Runtime.Core.Bootstrapper
{
    public class LevelBootstrapper : IInitializable
    {
        [Inject] private readonly StateFactory _stateFactory;
        [Inject] private readonly LevelStateMachine _fsm;
        [Inject] private readonly SelectedLevelProvider _selectedLevelProvider;
        [Inject] private readonly ILogService _logService;
        [Inject] private readonly ISaveLoadService _saveLoadService;
        
        public async void Initialize()
        {
#if UNITY_EDITOR
            // Required for the correct operation of BootFromAnyScene, since the editor executes after the container build
            await UniTask.Yield();
#endif
            _logService.Log($"Player started {_selectedLevelProvider.SelectedLevel.Name} level");
            
            var progress = _saveLoadService.Load();
            progress.UnlockedLevel++;
            _saveLoadService.Save(progress);
            
            CreateStates();
        }

        private void CreateStates()
        {
            _fsm.RegisterState(_stateFactory.Create<PlayingState>());
            _fsm.RegisterState(_stateFactory.Create<PauseState>());
        }
    }
}