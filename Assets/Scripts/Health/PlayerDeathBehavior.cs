using Shooter.Interfaces;
using UnityEngine;

namespace Shooter.Health {
    public class PlayerDeathBehavior : MonoBehaviour, IDeathBehavior {
        public void Die() {
            GameManager.Instance.RestartGame();
        }
    }
}