using System.Collections;
using KBCore.Refs;
using Shooter.Data;
using Shooter.Interfaces;
using UnityEngine;

namespace Shooter
{
    public class ExplosionBarrel : MonoBehaviour, IDamageInflector, IExplodable, IDeathBehavior
    {
        private Collider[] _results = new Collider[10];
        [Self, SerializeField] private Collider _collider;
        [Self, SerializeField] private Health.Health _health;
        [Self, SerializeField] private CharacterAttributes attributes;
        [SerializeField] private GameObject explosionFXPrefab;
        [SerializeField] private float explosionRadius = 5f;
        [field: SerializeField] public int Damage { get; set; }

        private void OnEnable()
        {
            attributes.OnHealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            attributes.OnHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int newHealth)
        {
            if (newHealth <= 0)
            {
                Die();
            }
        }

        public void Explode()
        {
            _collider.enabled = false;
            var fx = Instantiate(explosionFXPrefab, transform.position, Quaternion.identity);
            Destroy(fx, 10f);
            
            var size = Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, _results);
            for (var i = 0; i < size; i++)
            {
                var c = _results[i];
                if (!c) continue;
                if (c.TryGetComponent<Health.Health>(out var health) && health != _health)
                {
                    health.TakeDamage(Damage);
                }
            }

            StartCoroutine(DeferDestroy());
        }

        public async void Die()
        {
            await Awaitable.NextFrameAsync();
            Explode();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }

        private IEnumerator DeferDestroy()
        {
            yield return null;
            Destroy(gameObject);
        }
    }
}