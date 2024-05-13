using System;
using System.Collections;
using _Game.Scripts.Interfaces;
using Cysharp.Threading.Tasks.Triggers;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.PlayerControl
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth = 100;

        [SerializeField] private float _inmuneTime = 1;

        public event Action<float, float> OnTakeDamage;
        public event Action OnDie;
        public event Action<int> OnSetupHealth;

        private bool _isDead => _health <= 0;
        private int _health;
        private WaitForSeconds _waitingTime;
        private bool _isInmune;

        #region Unity function

        private void Awake()
        {
            _health = _maxHealth;
            _waitingTime = new WaitForSeconds(_inmuneTime);
        }

        private void Start()
        {
            OnSetupHealth?.Invoke(_health);
        }

        #endregion

        public void Setup(int maxHealth)
        {
            _maxHealth = maxHealth;
            _health = maxHealth;

            OnSetupHealth?.Invoke(_health);
        }

        public void Heal(int amount)
        {
            _health = Mathf.Min(_health + amount, _maxHealth);
            OnTakeDamage?.Invoke(0, _health);
        }

        #region IDamageable

        public bool TakeHit(int damage)
        {
            if (_isDead || _isInmune) return false;

            _health = Mathf.Max(_health - damage, 0);

            OnTakeDamage?.Invoke(damage, _health);
            StartCoroutine(Inmune());
            if (_isDead)
            {
                Die();
            }

            return true;
        }

        #endregion

        private void Die()
        {
            _isInmune = true;
            OnDie?.Invoke();
            transform.root.gameObject.SetActive(false);
        }

        private IEnumerator Inmune()
        {
            _isInmune = true;
            yield return _waitingTime;
            _isInmune = false;
        }
    }
}