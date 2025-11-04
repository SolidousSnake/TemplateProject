using System;
using _Project.Code.Runtime.Data.Config;
using TMPro;
using UnityEngine;

namespace _Project.Code.Runtime.UI.UIButton
{
    public class SelectLevelButton : BaseButton
    {
        [SerializeField] private TextMeshProUGUI _label;

        private LevelConfig _levelConfig;
        public event Action<LevelConfig> Pressed;
        
        public void Initialize(LevelConfig config, bool interactable)
        {
            _label.text = config.Name;
            _levelConfig = config;
            _button.interactable = interactable;
        }

        protected override void OnClick() => Pressed?.Invoke(_levelConfig);
    }
}