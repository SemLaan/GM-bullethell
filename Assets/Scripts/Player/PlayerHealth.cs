using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;

    public void removeHealth(int amount)
    {
        health -= amount;
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
