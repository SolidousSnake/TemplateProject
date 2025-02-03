using _Project.Code.Runtime.Core.Util;

namespace _Project.Code.Runtime.Data.Persistent
{
    [System.Serializable]
    public class SoundData
    {
        public float SfxVolume { get; set; }
        public float MusicVolume { get; set; }

        public SoundData()
        {
            SfxVolume = MusicVolume = Constants.Audio.DefaultValue;
        }
    }}