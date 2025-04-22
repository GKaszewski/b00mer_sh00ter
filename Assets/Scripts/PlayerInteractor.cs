using System;
using KBCore.Refs;
using Shooter.Input;
using Shooter.Interfaces;
using Shooter.Inventory;
using UnityEngine;

namespace Shooter
{
    public class PlayerInteractor : MonoBehaviour
    {
        private PlayerControls _controls;

        [SerializeField] private Camera mainCamera;
        [SerializeField] private float interactionDistance = 3f;
        [SerializeField] private LayerMask interactableLayer;
        [SerializeField, Self] private InventorySystem inventorySystem;

        private void OnEnable()
        {
            _controls = new PlayerControls();
            _controls.Enable();
            _controls.Player.Interact.performed += _ => TryInteract();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void TryInteract()
        {
            var ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            if (!Physics.Raycast(ray, out var hit, interactionDistance, interactableLayer)) return;
            if (!hit.collider.TryGetComponent<IInteractable>(out var interactable)) return;
            
            interactable.Interact(inventorySystem.Inventory);
        }
    }
}