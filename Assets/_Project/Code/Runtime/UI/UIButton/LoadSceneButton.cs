using _Project.Code.Runtime.Core.SceneManagement;
using UnityEngine;
using VContainer;

namespace _Project.Code.Runtime.UI.UIButton
{
    public class LoadSceneButton : BaseButton
    {
        [SerializeField] 
        // [Scene] Use TriInspector or NaughtyAttributes
        private string _scene; //Use [Scene] attribute
        [Inject] private ISceneLoader _sceneLoader;

        protected override void OnClick() => _sceneLoader.Load(_scene);
    }
}