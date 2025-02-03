using System;
using UniRx;

namespace _Project.Code.Runtime.Flow.Gameplay.Health
{
    public class Health
    {
        private readonly ReactiveProperty<float> _currentHealth;

        public IReadOnlyReactiveProperty<float> CurrentHealth => _currentHealth;

        public Health(int maxHealth)
        {
            SetMaxHealth(maxHealth);
            _currentHealth = new ReactiveProperty<float>(maxHealth);
        }

        public void SetMaxHealth(float value) => MaxHealth = value;
        
        public void ApplyDamage(float damage) => _currentHealth.Value = Math.Max(0, _currentHealth.Value - damage);

        public void ApplyHeal(float amount) => _currentHealth.Value = Math.Min(_currentHealth.Value + amount, MaxHealth);

        public float MaxHealth { get; private set; } 
    }
}