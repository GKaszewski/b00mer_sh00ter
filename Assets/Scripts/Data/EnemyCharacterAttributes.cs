using System;
using UnityEngine;

namespace Shooter.Data
{
    public class EnemyCharacterAttributes : CharacterAttributes
    {
        [SerializeField] private float _damageMultiplier;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _attackCooldown;
        
        public event Action<float> OnDamageMultiplierChanged;
        public event Action<float> OnAttackRangeChanged;
        public event Action<float> OnAttackCooldownChanged;
        
        public float DamageMultiplier
        {
            get => _damageMultiplier;
            private set
            {
                if (Math.Abs(_damageMultiplier - value) < 0.01) return;
                _damageMultiplier = value;
                OnDamageMultiplierChanged?.Invoke(_damageMultiplier);
            }
        }
        
        public float AttackRange
        {
            get => _attackRange;
            private set
            {
                if (Math.Abs(_attackRange - value) < 0.01) return;
                _attackRange = value;
                OnAttackRangeChanged?.Invoke(_attackRange);
            }
        }
        
        public float AttackCooldown
        {
            get => _attackCooldown;
            private set
            {
                if (Math.Abs(_attackCooldown - value) < 0.01) return;
                _attackCooldown = value;
                OnAttackCooldownChanged?.Invoke(_attackCooldown);
            }
        }
        
        public void SetDamageMultiplier(float value)
        {
            DamageMultiplier = value;
        }
        
        public void SetAttackRange(float value)
        {
            AttackRange = value;
        }
        
        public void SetAttackCooldown(float value)
        {
            AttackCooldown = value;
        }
    }
}