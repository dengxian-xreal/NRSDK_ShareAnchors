using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the Slider UI element
    public AudioSource audioSource; // Reference to the AudioSource

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volumeSlider.value; // Set the volume of the AudioSource to the value of the Slider
    }
}
