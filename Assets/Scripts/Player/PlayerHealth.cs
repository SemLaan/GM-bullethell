using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private string gameOverSceneName;
    [SerializeField] private GameObject[] healthDisplay;
    [SerializeField] private float invincibilityDuration;
    private AudioSource getHitSound;
    private float invincibilityStart = -10f;
    private int health;

    private void Awake()
    {
        health = healthDisplay.Length;
        getHitSound = GetComponent<AudioSource>();
    }

    public void RemoveHealth(int amount)
    {
        if (invincibilityStart + invincibilityDuration < Time.timeSinceLevelLoad)
        {
            invincibilityStart = Time.timeSinceLevelLoad;
            health -= amount;
            healthDisplay[health].SetActive(false);
            if (health <= 0)
            {
                GameOver();
            }
            else
            {
                getHitSound.Play();
            }
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
