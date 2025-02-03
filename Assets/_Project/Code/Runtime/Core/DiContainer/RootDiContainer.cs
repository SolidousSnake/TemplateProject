using _Project.Code.Runtime.Core.AssetManagement;
using _Project.Code.Runtime.Core.SceneManagement;
using _Project.Code.Runtime.Services.Localization;
using _Project.Code.Runtime.Services.Analytics;
using _Project.Code.Runtime.Services.SaveLoad;
using _Project.Code.Runtime.Services.Wallet;
using _Project.Code.Runtime.Services.Ads;
using _Project.Code.Runtime.Services.Log;
using _Project.Code.Runtime.Core.Factory;
using _Project.Code.Runtime.Core.Updater;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.Services.LevelSelection;
using _Project.Code.Runtime.Services.Settings;
using _Project.Code.Runtime.UI.View.LoadingCurtain;
using UnityEngine;
using UnityEngine.Audio;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.Runtime.Core.DiContainer
{
    public class RootDiContainer : DiContainerBase
    {
        [SerializeField] private AudioMixerGroup _mainMixer;
        [SerializeField] private GlobalUpdater _globalUpdater;
        [SerializeField] private LoadingCurtain _loadingCurtain;

        protected override void AddDependencies(IContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterUpdaters(builder);
            
            builder.AddTransient<StateFactory>();
            builder.AddSingleton<ConfigProvider>();
            builder.AddSingleton<SelectedLevelProvider>();

            builder.AddSingleton<ISceneLoader, SceneLoader>();
            builder.AddSingleton<IAssetProvider, ResourcesAssetProvider>();
            
            builder.RegisterBuildCallback(container =>
                DontDestroyOnLoad(container.Instantiate(_loadingCurtain)));
        }

        private void RegisterUpdaters(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_globalUpdater, Lifetime.Singleton);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.AddSingleton<ILocalizationService, LocalizationService>();
            builder.AddSingleton<ISaveLoadService, JsonSaveLoadService>();
            builder.AddSingleton<IAnalyticsService, AnalyticsService>();
            builder.AddSingleton<IAdsService, MobileAdsService>();
            builder.AddSingleton<ILogService, LogService>();
            
            builder.AddSingleton<SettingService>().WithParameter(_mainMixer);
            builder.AddSingleton<WalletService>();
        }
    }
}