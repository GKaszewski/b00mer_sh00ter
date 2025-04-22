using System;
using KBCore.Refs;
using Shooter.Data;
using Shooter.Interfaces;
using UnityEngine;

namespace Shooter.Health
{
    public class EnemyDeathBehavior : MonoBehaviour, IDeathBehavior
    {
        public void Die()
        {
            GameManager.Instance.playerAttributes.ModifyKills(1);
            GameManager.Instance.playerAttributes.ModifyScore(10);
            Destroy(gameObject);
        }
    }
}