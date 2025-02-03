using _Project.Code.Runtime.Flow.Gameplay.Health;
using TMPro;
using UniRx;
using UnityEngine;

namespace _Project.Code.Runtime.UI.Label
{
    public class HealthLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private string _prefix;        
        [SerializeField] private string _suffix;        
        
        private Health _health;
        
        public void Initialize(Health health)
        {
            _health = health;
            _health.CurrentHealth.Subscribe(SetAmount).AddTo(this); 
        }
        
        private void SetAmount(float currentHealth) => _label.text = _prefix + currentHealth + _suffix;
    }
}