using Shooter.Weapons.Data;
using UnityEngine;

namespace Shooter.Weapons {
    public class Weapon : MonoBehaviour
    {
        protected int CurrentAmmo;
        [SerializeField] protected WeaponStats stats;
        
        public WeaponStats Stats => stats;
        public int Ammo
        {
            get => CurrentAmmo;
            set => CurrentAmmo = value;
        }

        private void Awake() {
            CurrentAmmo = stats.magazineSize;
        }
    }
}