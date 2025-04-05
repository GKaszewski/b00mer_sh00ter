using KBCore.Refs;
using Shooter.Input;
using Shooter.Weapons.Interfaces;
using UnityEngine;

namespace Shooter.Weapons {
    using Inventory;

    public class WeaponController : MonoBehaviour {
        private PlayerControls _controls;
        [SerializeField, Self] private InventorySystem inventorySystem;
        [SerializeField] private Transform weaponHolder;
        private float _fireRateTimer;
        private int _currentWeaponIndex = 0;

        [SerializeField] private Weapon equippedWeapon;

        private void OnEnable() {
            _controls.Enable();
            _controls.Player.CycleWeapon.performed += _ => CycleWeapons();
            _controls.Player.NextWeapon.performed += _ => NextWeapon();
            _controls.Player.PreviousWeapon.performed += _ => PreviousWeapon();
        }
        
        private void OnDisable() {
            _controls.Disable();
        }

        private void Awake() {
            _controls = new PlayerControls();
            _controls.Enable();

            foreach (var weapon in inventorySystem.Inventory.Weapons) {
                weapon.gameObject.SetActive(false);
            }

            equippedWeapon = inventorySystem.Inventory.GetWeapon(_currentWeaponIndex);
            equippedWeapon.gameObject.SetActive(true);
        }

        private void Update() {
            _fireRateTimer += Time.deltaTime;

            if (equippedWeapon && _fireRateTimer >= equippedWeapon.Stats.fireRate &&
                _controls.Player.Fire.IsPressed()) {
                HandleFire();
            }
        }

        private void HandleFire() {
            if (equippedWeapon.Ammo <= 0) return;
            (equippedWeapon as IWeapon)?.Fire();
            _fireRateTimer = 0f;
        }

        private void SwitchWeapon() {
            equippedWeapon.gameObject.SetActive(false);
            equippedWeapon = inventorySystem.Inventory.GetWeapon(_currentWeaponIndex);
            equippedWeapon.gameObject.SetActive(true);
        }

        private void CycleWeapons() {
            _fireRateTimer = 0f;
            _currentWeaponIndex = (_currentWeaponIndex + 1) % inventorySystem.Inventory.Weapons.Count;
            SwitchWeapon();
        }

        private void NextWeapon() {
            _fireRateTimer = 0f;

            if (_currentWeaponIndex == inventorySystem.Inventory.Weapons.Count - 1) {
                _currentWeaponIndex = inventorySystem.Inventory.Weapons.Count - 1;
            }
            else {
                _currentWeaponIndex++;
            }

            SwitchWeapon();
        }

        private void PreviousWeapon() {
            _fireRateTimer = 0f;

            if (_currentWeaponIndex == 0) {
                _currentWeaponIndex = 0;
            }
            else {
                _currentWeaponIndex--;
            }

            SwitchWeapon();
        }
    }
}