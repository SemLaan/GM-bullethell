using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] pauseMenuObjects;
    private bool paused = false;
    private Controls controls;

    private void Start()
    {
        controls = FindObjectOfType<player>().controls;
        controls.Gameplay.Escape.performed += _ => Pause();
        controls.PauseMenu.Escape.performed += _ => Unpause();
        controls.PauseMenu.Space.performed += _ => QuitGame();
        controls.Gameplay.Enable();
    }

    private void Pause()
    {
        controls.Gameplay.Disable();
        controls.PauseMenu.Enable();
        Time.timeScale = 0;
        foreach (GameObject pauseMenuObject in pauseMenuObjects)
        {
            pauseMenuObject.SetActive(true);
        }
    }

    private void Unpause()
    {
        controls.Gameplay.Enable();
        controls.PauseMenu.Disable();
        Time.timeScale = 1;
        foreach (GameObject pauseMenuObject in pauseMenuObjects)
        {
            pauseMenuObject.SetActive(false);
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
