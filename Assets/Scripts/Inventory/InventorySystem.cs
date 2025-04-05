using UnityEngine;

namespace Shooter.Inventory {
    public class InventorySystem : MonoBehaviour {
        [SerializeField] private Inventory _inventory;
        public Inventory Inventory => _inventory;
        
        
    }
}