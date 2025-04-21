using System;
using KBCore.Refs;
using Shooter.Weapons.Interfaces;
using UnityEngine;

namespace Shooter.Weapons
{
    public class Projectile : MonoBehaviour, IDamageInflector
    {
        [Self, SerializeField] private Rigidbody rb;
        [field: SerializeField] public int Damage { get; set; } = 10;
        [field: SerializeField] public float Speed { get; set; } = 10f;
        [SerializeField] private float lifeTime = 5f;

        private void OnEnable()
        {
            Destroy(gameObject, lifeTime);
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = transform.forward * Speed;
        }

        private void OnCollisionEnter(Collision other)
        {
            other.gameObject.TryGetComponent<Health.Health>(out var health);
            if (health)
            {
                ApplyDamage(health);
            }

            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.TryGetComponent<Health.Health>(out var health);
            if (health)
            {
                ApplyDamage(health);
            }

            Destroy(gameObject);
        }

        private void ApplyDamage(Health.Health health)
        {
            health.TakeDamage(Damage);
        }
    }
}