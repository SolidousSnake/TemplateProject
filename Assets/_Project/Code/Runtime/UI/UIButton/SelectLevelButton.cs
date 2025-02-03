using System;
using _Project.Code.Runtime.Data.Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Runtime.UI.UIButton
{
    [RequireComponent(typeof(Button))]
    public class SelectLevelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _label;
        
        public event Action<LevelConfig> Pressed;
        
        public void Initialize(LevelConfig config, bool interactable)
        {
            _label.text = config.Name;
            _button.interactable = interactable;
            _button.onClick.AddListener(() => Pressed?.Invoke(config));
        }
    }
}