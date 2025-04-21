using KBCore.Refs;
using UnityEngine;

namespace Shooter.Weapons {
    public class HitscanBehavior : MonoBehaviour {
        private Transform _playerCameraTransform;
        
        [SerializeField] private int bulletCount = 1;
        [SerializeField] private float spread = 0.0f;
        [SerializeField, Child] private ParticleSystem muzzleFlash;
        
        private void Awake() {
            _playerCameraTransform = Camera.main.transform;
        }

        public void FireHitscan(int damage, float range) {
            muzzleFlash.Play();
            for (var i = 0; i < bulletCount; i++) {
                var origin = _playerCameraTransform.position;
                var direction = _playerCameraTransform.forward;
                
                direction += _playerCameraTransform.right * Random.Range(-spread, spread);
                direction += _playerCameraTransform.up * Random.Range(-spread, spread);
                
                if (Physics.Raycast(origin, direction, out var hit, range)) {
                    var collider = hit.collider;
                    collider.TryGetComponent<Health.Health>(out var health);
                    if (health) {
                        health.TakeDamage(damage);
                    }
                    
                    var targetRotation = Quaternion.LookRotation(hit.normal);
                    GameManager.Instance.decalSpawner.SpawnDecal(hit.point, targetRotation);
                }
            }
        }

    }
}