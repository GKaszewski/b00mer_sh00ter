using Shooter.Interfaces;
using UnityEngine;

namespace Shooter.Inventory
{
    public class AmmoCrate : MonoBehaviour, IPickable
    {
        [SerializeField] private AmmoItem _ammo;
        
        public void OnPickUp(Inventory inventory)
        {
            var weapon = inventory.GetWeaponOfStats(_ammo.weaponStats);
            weapon.Ammo += _ammo.quantity;
            Destroy(gameObject);
        }
    }
}