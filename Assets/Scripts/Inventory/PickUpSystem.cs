using System;
using KBCore.Refs;
using Shooter.Interfaces;
using UnityEngine;

namespace Shooter.Inventory
{
    public class PickUpSystem : MonoBehaviour
    {
        [Self, SerializeField] private InterfaceRef<IPickable> item;

        private void OnTriggerEnter(Collider other)
        {
            var inventorySystem = other.GetComponent<InventorySystem>();
            if (inventorySystem == null) return;

            var inventory = inventorySystem.Inventory;
            
            if (other.CompareTag("Player"))
            {
                item.Value.OnPickUp(inventory);
            }
        }
    }
}