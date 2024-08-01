using System;
using System.Collections;
using UnityEngine;

namespace Death
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField, Range(0, 200)] private int _maxHealth;
        [SerializeField, Range(0, 20)] private float _timeDestroy;

        public event Action<float> HealthChanged;

        private const int HealthAtDeath = 0;

        private int _currentHealth;

        private Animator _animator;

        private void Awake() => _animator = GetComponentInChildren<Animator>();

        private void Start() => _currentHealth = _maxHealth;

        public void Apply(int damage)
        {
            _currentHealth -= damage;

            float currentHealth = (float)_currentHealth / _maxHealth;

            HealthChanged?.Invoke(currentHealth);

            if (_currentHealth > HealthAtDeath) return;

            StartCoroutine(HealthForDestroy());
        }

        private IEnumerator HealthForDestroy()
        {
            _animator.enabled = false;
            yield return new WaitForSeconds(_timeDestroy);
            Destroy(gameObject);
        }
    }
}
