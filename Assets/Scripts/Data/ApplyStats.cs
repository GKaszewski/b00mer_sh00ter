using System;
using KBCore.Refs;
using UnityEngine;

namespace Shooter.Data
{
    public class ApplyStats : MonoBehaviour
    {
        [Self, SerializeField] private CharacterAttributes _characterAttributes;
        
        [Header("Easy mode stats")]
        [SerializeField] private CharacterStats easyModeStats;
        
        [Header("Normal mode stats")]
        [SerializeField] private CharacterStats normalModeStats;
        
        [Header("Hard mode stats")]
        [SerializeField] private CharacterStats hardModeStats;

        private void OnEnable()
        {
            GameManager.Instance.OnDifficultyChange += OnDifficultyChange;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnDifficultyChange -= OnDifficultyChange;
        }

        private void Start()
        {
            AssignStats();
        }

        private void OnDifficultyChange(GameDifficulty difficulty)
        {
            AssignStats();
        }

        private void AssignStats()
        {
            switch (GameManager.Instance.gameDifficulty)
            {
                case GameDifficulty.Easy:
                    ApplyCharacterStats(easyModeStats);
                    break;
                case GameDifficulty.Normal:
                    ApplyCharacterStats(normalModeStats);
                    break;
                case GameDifficulty.Hard:
                    ApplyCharacterStats(hardModeStats);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void ApplyCharacterStats(CharacterStats stats)
        {
            _characterAttributes.SetHealth(stats.health);
            _characterAttributes.SetArmor(stats.armor);
            _characterAttributes.SetMovementSpeed(stats.movementSpeed);
            _characterAttributes.SetJumpHeight(stats.jumpHeight);
            
            if (_characterAttributes is not EnemyCharacterAttributes enemyCharacterAttributes) return;
            
            enemyCharacterAttributes.SetDamageMultiplier(stats.damageMultiplier);
            enemyCharacterAttributes.SetAttackRange(stats.attackRange);
            enemyCharacterAttributes.SetAttackCooldown(stats.attackCooldown);
        }
    }
}