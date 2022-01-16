using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Text healthDisplay;

    public void removeHealth(int amount)
    {
        health -= amount;
        healthDisplay.text = "Health: " + health;
        if (health <= 0)
        {
            gameOver();
        }
    }

    private void gameOver()
    {
        print("you lost");
    }
}
