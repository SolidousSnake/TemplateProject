namespace _Project.Code.Runtime.Services.Ads
{
    public interface IAdsService
    {
        public bool TestMode { get; set; }
        public string AppKey { get; set; }

        public void Initialize();
        public void ShowBanner();
        public void HideBanner();
        public void ShowRewarded();
        public void ShowInterstitial();
    }
}