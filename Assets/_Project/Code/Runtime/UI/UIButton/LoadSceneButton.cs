using _Project.Code.Runtime.Core.SceneManagement;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Project.Code.Runtime.UI.UIButton
{
    [RequireComponent(typeof(Button))]
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField] 
        // [Scene] Use TriInspector or NaughtyAttributes
        private string _scene; //Use [Scene] attribute
        [SerializeField] private Button _button;
        [Inject] private ISceneLoader _sceneLoader;

        public void Start()
        {
            _button ??= GetComponent<Button>();
            _button.OnClickAsObservable().Subscribe(_ => _sceneLoader.Load(_scene)).AddTo(this);
        }
    }
}