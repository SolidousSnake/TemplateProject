using _Project.Code.Runtime.Core.AssetManagement;
using _Project.Code.Runtime.Core.SceneManagement;
using _Project.Code.Runtime.Core.StateMachine;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.Data.Config;
using _Project.Code.Runtime.Services.LevelSelection;
using _Project.Code.Runtime.Services.SaveLoad;
using _Project.Code.Runtime.UI.UIButton;
using _Project.Code.Runtime.UI.View.States.Lobby;

namespace _Project.Code.Runtime.Flow.Lobby.States
{
    public class SelectLevelState : IState
    {
        private readonly SelectLevelStateView _stateView;
        private readonly SelectedLevelProvider _selectedLevelProvider;
        private readonly ISceneLoader _sceneLoader;

        public SelectLevelState(SelectLevelStateView stateView
            , SelectedLevelProvider selectedLevelProvider
            , ConfigProvider configProvider
            , IAssetProvider assetProvider
            , ISaveLoadService saveLoadService
            , ISceneLoader sceneLoader)
        {
            var configs = configProvider.LoadMany<LevelConfig>(AssetPath.Config.Level);
            _stateView = stateView;
            _selectedLevelProvider = selectedLevelProvider;
            _sceneLoader = sceneLoader;

            _stateView.Initialize(
                assetProvider.Load<SelectLevelButton>(AssetPath.Prefab.UI.SelectLevelButton)
                , configs, saveLoadService.Load().UnlockedLevel);

            _stateView.LevelSelected += LoadLevel;
        }

        private void LoadLevel(LevelConfig levelConfig)
        {
            _selectedLevelProvider.SelectedLevel = levelConfig;
            _sceneLoader.Load(Constants.Scene.Game);
        }

        public void Enter() => _stateView.Open();

        public void Exit() => _stateView.Close();
    }
}