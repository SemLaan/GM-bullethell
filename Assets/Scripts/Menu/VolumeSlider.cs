using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Transform slider;
    [SerializeField] private float sliderSize;
    [SerializeField] private float sliderJumps;
    private Controls controls;
    private AudioSource getHitSound;

    private void Awake()
    {
        float sliderStartPosition = AudioListener.volume * sliderSize;
        slider.localPosition = new Vector3(sliderStartPosition, 0);
        getHitSound = GetComponent<AudioSource>();
        controls = new Controls();
        controls.Gameplay.Left.performed += _ => SlideVolume(true);
        controls.Gameplay.Right.performed += _ => SlideVolume(false);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void SlideVolume(bool left)
    {
        if (left)
        {
            AudioListener.volume = Mathf.Max(0, AudioListener.volume - sliderJumps);
            float sliderPosition = AudioListener.volume * sliderSize;
            slider.localPosition = new Vector3(sliderPosition, 0);
        }
        else
        {
            AudioListener.volume = Mathf.Min(1, AudioListener.volume + sliderJumps);
            float sliderPosition = AudioListener.volume * sliderSize;
            slider.localPosition = new Vector3(sliderPosition, 0);
        }
        getHitSound.Play();
    }
}
