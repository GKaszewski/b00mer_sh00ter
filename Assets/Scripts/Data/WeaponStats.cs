using UnityEngine;

namespace Shooter.Weapons.Data {
    [CreateAssetMenu(fileName = "WeaponStats", menuName = "Weapon/Stats", order = 1)]
    public class WeaponStats : ScriptableObject {
        public int damage;
        public float range;
        public float fireRate;
        public int magazineSize;
    }
}