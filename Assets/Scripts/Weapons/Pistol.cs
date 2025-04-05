using KBCore.Refs;
using Shooter.Weapons.Interfaces;
using UnityEngine;

namespace Shooter.Weapons {
    public class Pistol : Weapon, IWeapon {
        [SerializeField, Self] private HitscanBehavior hitscanBehavior;
        
        public void Fire() {
            if (CurrentAmmo <= 0) return;
            
            hitscanBehavior.FireHitscan(stats.damage, stats.range);
            CurrentAmmo--;
        }
    }
}