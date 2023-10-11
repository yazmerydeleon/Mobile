using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider; // Drag your volume slider here in the inspector.
    public AudioSource backgroundMusic; // Drag your background music's audio source here.

    private void Start()
    {
        // Initialize the slider's value with the current volume.
        volumeSlider.value = backgroundMusic.volume;

        // Subscribe to the value changed event of the slider.
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }
}
