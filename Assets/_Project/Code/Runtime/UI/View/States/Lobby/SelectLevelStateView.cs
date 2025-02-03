using System;
using _Project.Code.Runtime.Data.Config;
using _Project.Code.Runtime.UI.UIButton;
using _Project.Code.Runtime.UI.View.States.Lobby.Behaviour;
using UnityEngine;

namespace _Project.Code.Runtime.UI.View.States.Lobby
{
    [RequireComponent(typeof(BaseStateViewBehaviour))]
    public class SelectLevelStateView : MonoBehaviour
    {
        [SerializeField] private BaseStateViewBehaviour _behaviour;
        [SerializeField] private RectTransform _buttonParent;

        public event Action<LevelConfig> LevelSelected;

        public void Initialize(SelectLevelButton buttonPrefab, LevelConfig[] levels, int unlockedLevel)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                var button = Instantiate(buttonPrefab, _buttonParent);
                button.Initialize(levels[i], i <= unlockedLevel);
                button.Pressed += SelectLevel;
            }
        }

        private void SelectLevel(LevelConfig level) => LevelSelected?.Invoke(level);

        public void Open() => _behaviour.Open();
        public void Close() => _behaviour.Close();
    }
}