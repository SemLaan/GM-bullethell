using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTracker : MonoBehaviour
{
    public string previousLevel = "none";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
