using System.Collections.Generic;
using KBCore.Refs;
using Shooter.Interfaces;
using UnityEngine;

namespace Shooter.AI
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField, Self] private List<InterfaceRef<IAIBehavior>> behaviors = new();
        
        private void Update()
        {
            foreach (var behavior in behaviors)
            {
                behavior.Value.Tick();
            }
        }
    }
}