using _Project.Code.Runtime.Flow.Gameplay.Health;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace _Project.Code.Runtime.UI.Bar
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Image _fillImage;
        [SerializeField] private Color _fullHealthColor = Color.green;
        [SerializeField] private Color _lowHealthColor = Color.red;

        private Health _health;

        public void Initialize(Health health)
        {
            _health = health;
            _health.CurrentHealth.Subscribe(SetAmount).AddTo(this); 
        }

        private void SetAmount(float currentHealth)
        {
            float healthPercentage = (float)currentHealth / _health.MaxHealth;
            _healthSlider.value = healthPercentage;

            _fillImage.color = Color.Lerp(_lowHealthColor, _fullHealthColor, healthPercentage);
        }
    }
}