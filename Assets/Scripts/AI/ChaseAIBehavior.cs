using KBCore.Refs;
using Shooter.Interfaces;
using UnityEngine;

namespace Shooter.AI
{
    public class ChaseAIBehavior : MonoBehaviour, IAIBehavior
    {
        [SerializeField] private float speed = 3f;
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float stoppingDistance = 1f;
        [SerializeField] private Transform target;
        
        public void Tick()
        {
            if (!target) return;
            var direction = (target.position - transform.position).normalized;
            var step = speed * Time.deltaTime;
            var distance = Vector3.Distance(transform.position, target.position);
            
            if (!(distance > stoppingDistance)) return;
            
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            var targetRotation = Quaternion.LookRotation(-direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}