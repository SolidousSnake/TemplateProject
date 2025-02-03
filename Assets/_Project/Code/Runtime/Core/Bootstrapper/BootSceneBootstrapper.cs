using _Project.Code.Runtime.Core.SceneManagement;
using _Project.Code.Runtime.Core.Updater;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.Services.Ads;
using _Project.Code.Runtime.Services.Analytics;
using _Project.Code.Runtime.Services.SaveLoad;
using _Project.Code.Runtime.Services.Settings;
using _Project.Code.Runtime.Services.Wallet;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.Runtime.Core.Bootstrapper
{
    public class BootSceneBootstrapper : IInitializable
    {
        [Inject] private readonly ISceneLoader _sceneLoader;
        [Inject] private readonly IAdsService _adsService;
        [Inject] private readonly IAnalyticsService _analyticsService;
        [Inject] private readonly ISaveLoadService _saveLoadService;
        [Inject] private readonly SettingService _settingService;
        [Inject] private readonly WalletService _walletService;
        [Inject] private readonly GlobalUpdater _globalUpdater;

        public async void Initialize()
        {
#if UNITY_EDITOR
            // Required for the correct operation of BootFromAnyScene, since the editor executes after the container build
            await UniTask.Yield();
#endif
            _walletService.Initialize();
            _settingService.Initialize();
            _analyticsService.Initialize();
            _adsService.Initialize();
            _globalUpdater.Initialize();

            var progress = _saveLoadService.Load();
            _walletService.LoadFromProgress(progress);

            await _sceneLoader.Load(Constants.Scene.Lobby);
        }
    }
}