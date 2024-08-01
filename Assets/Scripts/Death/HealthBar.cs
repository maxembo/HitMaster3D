using UnityEngine;
using UnityEngine.UI;

namespace Death
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image _healthBarFilling;
        [SerializeField] private Gradient _gradient;

        private void Awake() => _health.HealthChanged += OnHealthChanged;

        private void OnDisable() => _health.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged(float currentHealth)
        {
            _healthBarFilling.fillAmount = currentHealth;
            _healthBarFilling.color = _gradient.Evaluate(currentHealth);

            if (currentHealth < 0)
                gameObject.SetActive(false);

        }
    }
}
