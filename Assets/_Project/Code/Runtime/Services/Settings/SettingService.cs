using _Project.Code.Runtime.Core.Util;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.Audio;
using VContainer;

namespace _Project.Code.Runtime.Services.Settings
{
    public class SettingService : IDisposable
    {
        [Inject] private AudioMixerGroup _mainMixer;

        private readonly CompositeDisposable _cd = new();
        private readonly ReactiveProperty<float> _musicVolume = new();
        private readonly ReactiveProperty<float> _sfxVolume = new();
        
        public IReadOnlyReactiveProperty<float> MusicVolume => _musicVolume;
        public IReadOnlyReactiveProperty<float> SfxVolume => _sfxVolume;

        public void Initialize()
        {
            _musicVolume.Subscribe(volume => _mainMixer.audioMixer.SetFloat(Constants.Audio.Music, volume))
                .AddTo(_cd);
        
            _sfxVolume.Subscribe(volume => _mainMixer.audioMixer.SetFloat(Constants.Audio.SFX, volume))
                .AddTo(_cd);
        }
        
        public int SetTargetFrameRate(int frameRate) => Application.targetFrameRate = frameRate;
        
        public void SetSfxVolume(float volume) => _sfxVolume.Value = Constants.Audio.MuteValue + volume * 100;
        
        public void SetMusicVolume(float volume) => _musicVolume.Value = Constants.Audio.MuteValue + volume * 100;

        public void Dispose() => _cd.Dispose();
    }
}