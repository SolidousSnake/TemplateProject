using System.Collections.Generic;
using _Project.Code.Runtime.Data.Enum;

namespace _Project.Code.Runtime.Data.Persistent
{
    [System.Serializable]
    public class PlayerProgress
    {
        public Dictionary<CurrencyType, int> Wallets;
        public SoundData SoundData;
        public int UnlockedLevel;

        public PlayerProgress()
        {
            Wallets ??= new Dictionary<CurrencyType, int>();
            SoundData ??= new SoundData();
        }
    }
}