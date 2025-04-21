using System;
using Shooter.Weapons.Data;

namespace Shooter.Inventory
{
    [Serializable]
    public class AmmoItem : Item
    {
        public WeaponStats weaponStats;
    }
}