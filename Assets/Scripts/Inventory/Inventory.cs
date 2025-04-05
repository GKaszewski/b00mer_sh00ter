using System;
using System.Collections.Generic;
using Shooter.Weapons;
using UnityEngine;

namespace Shooter.Inventory {
    [Serializable]
    public class Inventory {
        [SerializeField] private List<Item> items = new();
        [SerializeField] private List<KeyCard> keyCards = new();
        [SerializeField] private List<Weapon> weapons = new();
        
        public List<Item> Items => items;
        public List<KeyCard> KeyCards => keyCards;
        public List<Weapon> Weapons => weapons;
        
        public void AddItem(Item item) {
            items.Add(item);
        }

        public bool HasItem(Item item) {
            return items.Contains(item);
        }

        public void RemoveItem(Item item) {
            if (!HasItem(item)) return;

            items.Remove(item);
        }
        
        public void AddKeyCard(KeyCard keyCard) {
            if (HasKeyCard(keyCard)) return;
            
            keyCards.Add(keyCard);
        }
        
        public bool HasKeyCard(KeyCard keyCard) {
            return keyCards.Contains(keyCard);
        }
        
        public void RemoveKeyCard(KeyCard keyCard) {
            if (!HasKeyCard(keyCard)) return;

            keyCards.Remove(keyCard); 
        }
        
        public void AddWeapon(Weapon weapon) {
            weapons.Add(weapon);
        }
        
        public bool HasWeapon(Weapon weapon) {
            return weapons.Contains(weapon);
        }
        
        public void RemoveWeapon(Weapon weapon) {
            if (!HasWeapon(weapon)) return;

            weapons.Remove(weapon);
        }

        public Weapon GetWeapon(int index) {
            return weapons[index];
        }
    }
}