﻿using Shooter.Interfaces;
using UnityEngine;

namespace Shooter.Health {
    public class PlayerDeathBehavior : MonoBehaviour, IDeathBehavior {
        public void Die() {
            GameManager.Instance.playerAttributes.ModifyDeaths(1);
            GameManager.Instance.RestartGame();
        }
    }
}