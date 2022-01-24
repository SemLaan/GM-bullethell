using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public string levelNumber;
    [SerializeField] private Transform progressBarScaler;
    [SerializeField] private int progressBarSizeInPixels;
    [SerializeField] private float levelDuration = 20;
    private float timeSinceStart = 0f;
    private SceneTracker sceneTracker;

    private void Awake()
    {
        sceneTracker = FindObjectOfType<SceneTracker>();
    }

    private void FixedUpdate()
    {
        timeSinceStart += Time.fixedDeltaTime;
        progressBarScaler.localScale = new Vector3(Mathf.Floor((timeSinceStart / levelDuration) * progressBarSizeInPixels), 1);
        // Checking if the player won
        if (timeSinceStart > levelDuration)
        {
            sceneTracker.previousLevel = "Level" + levelNumber;
            SceneManager.LoadScene("WonLevel" + levelNumber);
        }
    }
}
