using System;
using KBCore.Refs;
using Shooter.Data;
using UnityEngine;

namespace Shooter.Health {
    public class Health : MonoBehaviour {
        [SerializeField, Self] private CharacterAttributes _attributes;
        [SerializeField] private int _initialHealth;

        private void Start() {
            _attributes.SetHealth(_initialHealth);
        }

        public void TakeDamage(int damage) {
            _attributes.ModifyHealth(-damage);
        }
    }
}