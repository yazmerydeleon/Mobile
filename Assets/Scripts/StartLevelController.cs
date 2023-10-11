using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartLevelController : MonoBehaviour
{
    public GameObject StartOfLevelPanel;  // Drag the StartOfLevelPanel UI GameObject here in the Inspector
    public AudioSource gameMusic;  // Drag your Audio Source component (that plays the music) here in the Inspector
    public SongManager songManager; // Reference to the SongManager
    public bool IsEasyModeSelected { get; private set; } = true; // Default to true or easy mode
    public UnityEvent OnModeSelected;  // Event triggered when a mode is selected

    public TempoBasedSpawnRateController tempoBasedSpawnRateController; // Drag and drop the TempoBasedSpawnRateController here
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
        IsEasyModeSelected = true;

        // Fetch the SongData for Easy mode
        SongData easySongData = songManager.GetCurrentSongData(true, 0);

        gameMusic.clip = Resources.Load<AudioClip>(easySongData.songName);

        StartGame(); // This starts the game and music

        tempoBasedSpawnRateController.Initialize();

        OnModeSelected?.Invoke();
    }

    // Called when the Hard button is clicked
    public void StartHardMode()
    {
        IsEasyModeSelected = false;

        // Fetch the SongData for Hard mode
        SongData hardSongData = songManager.GetCurrentSongData(false, 0);

        // Find and set the respective AudioClip for the hard mode
        gameMusic.clip = Resources.Load<AudioClip>(hardSongData.songName);

        StartGame(); // This starts the game and music

        tempoBasedSpawnRateController.Initialize();

        OnModeSelected?.Invoke();
    }

    private void StartGame()
    {
        Time.timeScale = 1;  // Resume the game
        StartOfLevelPanel.SetActive(false);  // Hide the start panel
        gameMusic.Play();  // Start the game music
    }
    
}
