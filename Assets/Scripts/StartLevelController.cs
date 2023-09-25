using UnityEngine;
using UnityEngine.UI;

public class StartLevelController : MonoBehaviour
{
    public GameObject StartOfLevelPanel;  // Drag the StartOfLevelPanel UI GameObject here in the Inspector
    public AudioSource gameMusic;  // Drag your Audio Source component (that plays the music) here in the Inspector
    public AudioClip easyModeSong; // Drag the EasyModeSong here in the Inspector
    public AudioClip hardModeSong; // Drag the HardModeSong here in the Inspector

    private void Start()
    {
        Time.timeScale = 0;  // Pause the game
        StartOfLevelPanel.SetActive(true);  // Ensure the panel is visible
       // gameMusic.Stop(); // Make sure the music is not playing
         gameMusic.Play(); 
    }

    // Called when the Easy button is clicked
    public void StartEasyMode()
    {
        gameMusic.clip = easyModeSong; // Set the song for easy mode
        StartGame(); // This starts the game and music
    }

    // Called when the Hard button is clicked
    public void StartHardMode()
    {
        gameMusic.clip = hardModeSong; // Set the song for hard mode
        StartGame(); // This starts the game and music
    }

    private void StartGame()
    {
        Time.timeScale = 1;  // Resume the game
        StartOfLevelPanel.SetActive(false);  // Hide the start panel
        gameMusic.Play();  // Start the game music
    }

    // Implement other button functions below as needed
}
