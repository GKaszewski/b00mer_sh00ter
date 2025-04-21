using KBCore.Refs;
using Shooter.Interfaces;
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
            if (other.gameObject.TryGetComponent<Health.Health>(out var health))
            {
                ApplyDamage(health);
            }
            
            var targetRotation = Quaternion.LookRotation(other.contacts[0].normal);
            GameManager.Instance.decalSpawner.SpawnDecal(transform.position, targetRotation);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Health.Health>(out var health))
            {
                ApplyDamage(health);
            }
            
            var targetRotation = Quaternion.LookRotation(other.transform.forward);
            GameManager.Instance.decalSpawner.SpawnDecal(transform.position, targetRotation);
            Destroy(gameObject);
        }

        private void ApplyDamage(Health.Health health)
        {
            health.TakeDamage(Damage);
        }
    }
}