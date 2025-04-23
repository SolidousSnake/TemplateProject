using _Project.Code.Runtime.UI.Appearance;
using UnityEngine;

namespace _Project.Code.Runtime.UI.View.States.Level
{
    public class PlayingStateView : MonoBehaviour
    {
        [SerializeField] private BaseViewAppearance _appearance;

        private void OnValidate() => _appearance ??= GetComponent<BaseViewAppearance>();

        public void Open() => _appearance.Open();
        public void Close() => _appearance.Close();
    }
}