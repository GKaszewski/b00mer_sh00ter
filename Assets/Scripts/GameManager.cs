using System;
using Shooter.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shooter {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance { get; private set; }
        
        public CharacterAttributes playerAttributes;
        public Inventory.Inventory playerInventory;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            } else {
                Destroy(gameObject);
                return;
            }
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