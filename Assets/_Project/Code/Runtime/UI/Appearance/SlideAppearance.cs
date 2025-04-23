using UnityEngine;

namespace _Project.Code.Runtime.UI.Appearance
{
    public class SlideAppearance : BaseViewAppearance
    {
        //Implement DOTween
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Vector2 _originalPosition;
        [SerializeField] private Vector2 _targetPosition;
        [SerializeField] private float _appearDuration;
        [SerializeField] private float _disappearDuration;
        // [SerializeField] private Ease _appearEase;
        // [SerializeField] private Ease _disappearEase;
        
        private void OnValidate() => _rectTransform ??= GetComponent<RectTransform>();

        public override void Open()
        {
            // DOTween.Sequence().Append(_rectTransform.DOAnchorPos(_targetPosition, _appearDuration)).SetEase(_appearEase);
        }

        public override void Close()
        {
            // DOTween.Sequence().Append(_rectTransform.DOAnchorPos(_originalPosition, _disappearDuration)).SetEase(_disappearEase);
        }
    }
}