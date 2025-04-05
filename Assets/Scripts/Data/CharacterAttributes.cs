using System;
using UnityEngine;

namespace Shooter.Data {
    public class CharacterAttributes : MonoBehaviour {
        [SerializeField] private int _health;
        [SerializeField] private int _armor;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private int _score;
        [SerializeField] private int _highScore;
        [SerializeField] private int _kills;
        [SerializeField] private int _deaths;
        [SerializeField] private bool _isInvincible;
        
        public event Action<int> OnHealthChanged;
        public event Action<int> OnArmorChanged;
        public event Action OnDamage;
        public event Action<float> OnMovementSpeedChanged;
        public event Action<float> OnJumpHeightChanged;
        public event Action<int> OnScoreChanged;
        public event Action<int> OnHighScoreChanged;
        public event Action<int> OnKillsChanged;
        public event Action<int> OnDeathsChanged;
        public event Action<bool> OnInvincibilityChanged;
        
        public int Health {
            get => _health;
            private set {
                if (Math.Abs(_health - value) < 0.01) return;
                _health = value;
                OnHealthChanged?.Invoke(_health);
            }
        }
        
        public int Armor {
            get => _armor;
            private set {
                _armor = value;
                OnArmorChanged?.Invoke(_armor);
            }
        }
        
        public float MovementSpeed {
            get => _movementSpeed;
            private set {
                _movementSpeed = value;
                OnMovementSpeedChanged?.Invoke(_movementSpeed);
            }
        }
        
        public float JumpHeight {
            get => _jumpHeight;
            private set {
                _jumpHeight = value;
                OnJumpHeightChanged?.Invoke(_jumpHeight);
            }
        }
        
        public int Score {
            get => _score;
            private set {
                if (_score == value) return;
                _score = value;
                OnScoreChanged?.Invoke(_score);
                CheckForNewHighScore();
            }
        }
        
        public int HighScore {
            get => _highScore;
            private set {
                if (_highScore == value) return;
                _highScore = value;
                OnHighScoreChanged?.Invoke(_highScore);
            }
        }
        
        public int Kills {
            get => _kills;
            private set {
                if (_kills == value) return;
                _kills = value;
                OnKillsChanged?.Invoke(_kills);
            }
        }
        
        public int Deaths {
            get => _deaths;
            private set {
                if (_deaths == value) return;
                _deaths = value;
                OnDeathsChanged?.Invoke(_deaths);
            }
        }
        
        public bool IsInvincible {
            get => _isInvincible;
            private set {
                if (_isInvincible == value) return;
                _isInvincible = value;
                OnInvincibilityChanged?.Invoke(_isInvincible);
            }
        }

        public void ModifyHealth(int amount) {
            Health += amount;
            if (amount < 0) {
                OnDamage?.Invoke();
            }
        }
        
        public void SetHealth(int amount) {
            Health = amount;
        }
        
        public void ModifyArmor(int amount) {
            Armor += amount;
        }
        
        public void SetArmor(int amount) {
            Armor = amount;
        }
        
        public void ModifyMovementSpeed(float amount) {
            MovementSpeed += amount;
        }
        
        public void SetMovementSpeed(float amount) {
            MovementSpeed = amount;
        }
        
        public void ModifyJumpHeight(float amount) {
            JumpHeight += amount;
        }
        
        public void SetJumpHeight(float amount) {
            JumpHeight = amount;
        }
        
        public void ModifyScore(int amount) {
            Score += amount;
        }
        
        public void SetScore(int amount) {
            Score = amount;
        }
        
        public void ModifyHighScore(int amount) {
            HighScore += amount;
        }
        
        public void SetHighScore(int amount) {
            HighScore = amount;
        }
        
        public void ResetScore() {
            Score = 0;
        }
        
        public void ModifyKills(int amount) {
            Kills += amount;
        }
        
        public void SetKills(int amount) {
            Kills = amount;
        }
        
        public void ModifyDeaths(int amount) {
            Deaths += amount;
        }
        
        public void SetDeaths(int amount) {
            Deaths = amount;
        }
        
        public void SetInvincibility(bool value) {
            IsInvincible = value;
        }

        private void CheckForNewHighScore() {
            if (_score > _highScore) {
                _highScore = _score;
            }
        }
        
    }
}