using _Project.Code.Runtime.Core.Bootstrapper;
using _Project.Code.Runtime.Core.StateMachine;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.UI.View.States.Level;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.Runtime.Core.DiContainer
{
    public class LevelDiContainer : DiContainerBase
    {
        [Header("View")]
        [SerializeField] private PlayingStateView _playingStateView;
        [SerializeField] private PauseStateView _pauseStateView;
        
        protected override void AddDependencies(IContainerBuilder builder)
        {
            RegisterUI(builder);

            builder.AddSingleton<LevelStateMachine>();
            builder.RegisterEntryPoint<LevelBootstrapper>();
        }

        private void RegisterUI(IContainerBuilder builder)
        {
            builder.RegisterInstance(_playingStateView);
            builder.RegisterInstance(_pauseStateView);
        }
    }
}