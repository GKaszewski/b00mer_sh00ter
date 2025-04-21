using Shooter.Interfaces;
using UnityEngine;

namespace Shooter.Inventory {
    public class KeyCardObject : MonoBehaviour, IPickable {
        [SerializeField] private KeyCard keyCard;
        public KeyCard KeyCard => keyCard;
        
        public void OnPickUp(Inventory inventory) {
            GameManager.Instance.playerInventorySystem.Inventory.AddKeyCard(keyCard);
            Destroy(gameObject);
        }
    }
}