using System;

namespace Shooter.Inventory {
    public enum KeyCardType {
        Red,
        Green,
        Blue
    }

    [Serializable]
    public class KeyCard {
        public KeyCardType type;
    }
}