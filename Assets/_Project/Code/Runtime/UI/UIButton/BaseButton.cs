using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace _Project.Code.Runtime.UI.UIButton
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField] protected Button _button;
        
        private void OnValidate() => _button ??= GetComponent<Button>();
        private void Start() => _button.OnClickAsObservable().Subscribe(_ => OnClick()).AddTo(this);
        protected abstract void OnClick();
    }
}