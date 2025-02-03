using _Project.Code.Runtime.Core.SceneManagement;
using TMPro;
using UnityEngine;
using VContainer;

namespace _Project.Code.Runtime.UI.View.LoadingCurtain
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtainCanvasGroup;
        [SerializeField] private TextMeshProUGUI _percentLabel;

        [Inject] private ISceneLoader _sceneLoader;
        
        private void Awake()
        {
            Hide();
            SetProgress(0);

            _sceneLoader.OnLoadingStarted += Show;
            _sceneLoader.OnLoadingProgress += SetProgress;
            _sceneLoader.OnLoadingCompleted += Hide;
        }

        private void Show()
        {
            _curtainCanvasGroup.alpha = 1;
            _curtainCanvasGroup.blocksRaycasts = true;
        }

        private void Hide()
        {
            _curtainCanvasGroup.alpha = 0;
            _curtainCanvasGroup.blocksRaycasts = false;
            SetProgress(0);
        }

        private void SetProgress(float progress)
        {
            _percentLabel.text = Mathf.RoundToInt(progress * 100) + "%";
        }

        private void OnDestroy()
        {
            _sceneLoader.OnLoadingStarted -= Show;
            _sceneLoader.OnLoadingProgress -= SetProgress;
            _sceneLoader.OnLoadingCompleted -= Hide;
        }
    }
}