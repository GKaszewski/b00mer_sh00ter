using System;
using UnityEngine;

namespace Shooter.Inventory {
    [Serializable]
    public class Item {
        public string name;
        public Sprite icon;
        public int quantity;
        public bool isStackable;
        public float duration;
    }
}