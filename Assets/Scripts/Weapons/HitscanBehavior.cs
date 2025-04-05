using UnityEngine;

namespace Shooter.Weapons {
    public class HitscanBehavior : MonoBehaviour {
        private Transform _playerCameraTransform;
        
        [SerializeField] private int bulletCount = 1;
        [SerializeField] private float spread = 0.0f;
        
        private void Awake() {
            _playerCameraTransform = Camera.main.transform;
        }

        public void FireHitscan(float damage, float range) {
            for (var i = 0; i < bulletCount; i++) {
                var direction = _playerCameraTransform.forward;
                var position = transform.position;
                position += transform.right * Random.Range(-spread, spread);
                Debug.DrawRay(position, direction * range, Color.red, 1f);
                RaycastHit hit;
                if (Physics.Raycast(position, direction, out hit, range)) {
                    //TODO: Apply damage to hit object
                }
            }
        }
    }
}