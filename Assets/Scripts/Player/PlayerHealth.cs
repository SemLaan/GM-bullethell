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

    public void RemoveHealth(int amount)
    {
        health -= amount;
        healthDisplay.text = "Health: " + health;
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
