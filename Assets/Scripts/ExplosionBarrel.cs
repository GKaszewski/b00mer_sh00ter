using System.Collections;
using KBCore.Refs;
using Shooter.Data;
using Shooter.Weapons.Interfaces;
using UnityEngine;

namespace Shooter
{
    public class ExplosionBarrel : MonoBehaviour, IDamageInflector, IExplodable, IDeathBehavior
    {
        private Collider[] _results = new Collider[10];
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
            var fx = Instantiate(explosionFXPrefab, transform.position, Quaternion.identity);
            Destroy(fx, 10f);
            
            Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, _results);
            foreach (var c in _results)
            {
                if (!c) continue;
                
                var health = c.GetComponent<Health.Health>();
                if (health && health.gameObject && _health != health)
                {
                    health.TakeDamage(Damage);
                }
            }

            StartCoroutine(DeferDestroy());
        }

        public void Die()
        {
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