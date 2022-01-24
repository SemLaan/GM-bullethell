using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private Controls controls;
    private SceneTracker sceneTracker;

    private void Awake()
    {
        controls = new Controls();
        controls.Gameplay.Space.performed += _ => StartGame();
        sceneTracker = FindObjectOfType<SceneTracker>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(sceneTracker.previousLevel);
    }
}
