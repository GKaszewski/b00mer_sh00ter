using UnityEngine;

namespace Shooter.Weapons {
    public class ProjectileBehavior : MonoBehaviour {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform projectileSpawnPoint;
        [SerializeField] private float projectileSpeed = 10f;

        public void FireProjectile(float damage) {
            var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
            
            projectile.transform.rotation = Quaternion.identity;
            projectile.transform.LookAt(projectileSpawnPoint.position + projectileSpawnPoint.forward);
            
            var rb = projectile.GetComponent<Rigidbody>();
            rb.linearVelocity = projectileSpawnPoint.forward * projectileSpeed;
            
            //TODO: Pass damage to projectile
        }
    }
}