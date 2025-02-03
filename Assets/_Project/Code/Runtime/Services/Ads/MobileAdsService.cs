namespace _Project.Code.Runtime.Services.Ads
{
    public class MobileAdsService : IAdsService
    {
        public bool TestMode { get; set; }
        public string AppKey { get; set; }

        public void Initialize()
        {
        }

        public void ShowRewarded()
        {
        }

        public void ShowInterstitial()
        {
        }
    }
}