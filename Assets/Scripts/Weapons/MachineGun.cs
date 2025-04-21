using KBCore.Refs;
using Shooter.Interfaces;
using UnityEngine;

namespace Shooter.Weapons {
    public class MachineGun : Weapon, IWeapon {
        [SerializeField, Self] private ProjectileBehavior projectileBehavior;

        public void Fire() {
            if (CurrentAmmo <= 0) return;
            
            projectileBehavior.FireProjectile(stats.damage);
            CurrentAmmo--;
        }
    }
}