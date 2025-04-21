using System;
using KBCore.Refs;
using Shooter.Data;
using Shooter.Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shooter {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance { get; private set; }
        
        [Scene] public CharacterAttributes playerAttributes;
        [Scene] public InventorySystem playerInventorySystem;
        public GameDifficulty gameDifficulty;

        public event Action<GameDifficulty> OnDifficultyChange;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            } else {
                Destroy(gameObject);
                return;
            }
            
            OnDifficultyChange?.Invoke(gameDifficulty);
            Debug.Log($"Changed difficulty to {gameDifficulty}");
        }

        public void RestartGame() {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
        
        public void IncreaseScore(int amount) {
            playerAttributes.ModifyScore(amount);
        }
        
        public void ResetPlayerScore() {
            playerAttributes.ResetScore();
        }
    }
}