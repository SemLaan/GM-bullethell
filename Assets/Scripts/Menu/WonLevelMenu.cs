using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonLevelMenu : MonoBehaviour
{
    [SerializeField] private string nextLevelNumber;
    private Controls controls;

    private void Awake()
    {
        controls = new Controls();
        controls.Gameplay.Space.performed += _ => StartGame();
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
        SceneManager.LoadScene("Level" + nextLevelNumber);
    }
}
