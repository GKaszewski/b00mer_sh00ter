using System.Linq;
using Shooter.Interfaces;
using Shooter.Inventory;
using UnityEngine;

namespace Shooter
{
    public class KeyCardDoor : MonoBehaviour, IInteractable
    {
        [SerializeField] private KeyCardType keyCardType;
        [SerializeField] private bool isOpen;
        [SerializeField] private bool autoClose;
        [SerializeField] private float autoCloseDelay = 3f;

        private bool HasKeyCard(Inventory.Inventory inventory)
        {
            return inventory.KeyCards.Any(k => k.type == keyCardType);
        }

        private async void OpenDoor()
        {
            isOpen = true;
            // Add logic to open the door, e.g., play an animation or change the door's state
            transform.Translate(Vector3.up * 3f);

            if (!autoClose) return;
            
            await Awaitable.WaitForSecondsAsync(autoCloseDelay);
            CloseDoor();
        }

        private void CloseDoor()
        {
            isOpen = false;
            // Add logic to close the door, e.g., play an animation or change the door's state
            transform.Translate(Vector3.down * 3f);
        }

        public void Interact(Inventory.Inventory inventory)
        {
            if (isOpen) return;

            var hasKey = HasKeyCard(inventory);
            if (hasKey) OpenDoor();
            else
            {
                // Add logic to show a message to the player, e.g., "You need a key card to open this door."
            }
        }
    }
}