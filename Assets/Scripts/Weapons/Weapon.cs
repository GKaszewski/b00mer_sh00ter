using Shooter.Weapons.Data;
using UnityEngine;

namespace Shooter.Weapons {
    public class Weapon : MonoBehaviour {
        protected int CurrentAmmo;
        [SerializeField] protected WeaponStats stats;
        
        public WeaponStats Stats => stats;
        public int Ammo => CurrentAmmo;

        private void Awake() {
            CurrentAmmo = stats.magazineSize;
        }
    }
}