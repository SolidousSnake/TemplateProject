using _Project.Code.Runtime.Core.Bootstrapper;
using _Project.Code.Runtime.Core.StateMachine;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.UI.View.States.Lobby;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.Runtime.Core.DiContainer
{
    public class LobbyDiContainer : DiContainerBase
    {
        [Header("View")] 
        [SerializeField] private HubStateView _hubStateView;
        [SerializeField] private ShopStateView _shopStateView;
        [SerializeField] private SettingStateView _settingsStateView;
        [SerializeField] private SelectLevelStateView _selectLevelStateView;

        protected override void AddDependencies(IContainerBuilder builder)
        {
            RegisterUI(builder);
            
            builder.AddSingleton<LobbyStateMachine>();
            builder.RegisterEntryPoint<LobbyBootstrapper>();
        }

        private void RegisterUI(IContainerBuilder builder)
        {
            builder.RegisterInstance(_hubStateView);
            builder.RegisterInstance(_shopStateView);
            builder.RegisterInstance(_settingsStateView);
            builder.RegisterInstance(_selectLevelStateView);
        }
    }
}