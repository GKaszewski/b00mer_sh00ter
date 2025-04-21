using UnityEngine;

namespace Shooter.Data
{
    [CreateAssetMenu(fileName = "Character Stats", menuName = "Character/Stats", order = 0)]
    public class CharacterStats : ScriptableObject
    {
        public int health;
        public int armor;
        public float movementSpeed;
        public float jumpHeight;
        public float damageMultiplier;
        public float attackRange;
        public float attackCooldown;
    }
}