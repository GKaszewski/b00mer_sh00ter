using UnityEngine;

namespace Shooter
{
    public class DecalSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject decalPrefab;
        [SerializeField] private float decalLifetime = 5f;
        
        public void SpawnDecal(Vector3 position, Quaternion rotation)
        {
            var decal = Instantiate(decalPrefab, position, rotation);
            Destroy(decal, decalLifetime);
        }
    }
}