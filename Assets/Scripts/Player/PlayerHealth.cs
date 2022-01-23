using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private string gameOverSceneName;
    [SerializeField] private int health;
    [SerializeField] private Text healthDisplay;
    [SerializeField] private float invincibilityDuration;
    private float invincibilityStart = -10f;

    public void RemoveHealth(int amount)
    {
        if (invincibilityStart + invincibilityDuration < Time.timeSinceLevelLoad)
        {
            invincibilityStart = Time.timeSinceLevelLoad;
            health -= amount;
            healthDisplay.text = "Health: " + health;
            if (health <= 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
