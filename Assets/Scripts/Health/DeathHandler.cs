using KBCore.Refs;
using Shooter.Data;
using Shooter.Interfaces;
using UnityEngine;

namespace Shooter.Health
{
    public class DeathHandler : MonoBehaviour
    {
        [Self, SerializeField] private CharacterAttributes characterAttributes;
        [Self, SerializeField] private InterfaceRef<IDeathBehavior> deathBehavior;
        private void OnEnable()
        {
            characterAttributes.OnHealthChanged += OnHealthChanged;
        }
        
        private void OnDisable()
        {
            characterAttributes.OnHealthChanged -= OnHealthChanged;
        }
        
        private void OnHealthChanged(int newHealth)
        {
            if (newHealth <= 0)
            {
                Die();
            }
        }
        
        private void Die()
        {
            deathBehavior.Value.Die();
        }
    }
}