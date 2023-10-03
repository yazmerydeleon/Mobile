using System.Collections;
using UnityEngine;

public enum GameMode { Easy, Hard }

public class TempoBasedSpawnRateController : MonoBehaviour
{
    [Header("Song Management")]
    public SongManager songManager;

    [Header("Controllers")]
    public StartLevelController startLevelController;  // Drag and drop the StartLevelController here

    public int currentLevelIndex = 0; // Which level (0-based index)

    [Header("Prompt Prefabs and Spawn Points")]
    [SerializeField] private GameObject[] promptPrefabs;  // Array of rhythmic prompt prefabs
    [SerializeField] private Transform[] spawnPoints; // Array of spawn points

    [Header("Spawn Rate Configuration")]
    [SerializeField] private float spawnRate = 2.0f; // Initial spawn rate
    private float nextSpawnTime = 0;
    private float lastSpawnTime = 0; // To keep track of the last spawn time
    private float spawnBuffer = 0.9f;  // Adjust this value as needed to ensure a buffer between spawns

    private float[] tempoChangeTimes; // The times (in seconds) when tempo changes
    private float[] spawnRatesForTempos; // The spawn rates for each tempo
    private int currentTempoIndex = 0; // To track which tempo we're currently on

    //The purpose here is to provide a method to set up the TempoBasedSpawnRateController with the appropriate game mode after a player's selection.

    public void Initialize()
    {
        bool isEasyMode = startLevelController.IsEasyModeSelected;

        Debug.Log("isEasyMode:" + isEasyMode);

        // Fetching the song data based on the mode
        SongData currentSong = songManager.GetCurrentSongData(isEasyMode, currentLevelIndex);
        tempoChangeTimes = currentSong.tempoChangeTimes;
        spawnRatesForTempos = currentSong.spawnRatesForTempos;
    }
    private void Update()
    {
        // Check if the game is active before doing anything else
        if (!LevelTimer.isGameActive) return;
        if (tempoChangeTimes == null) return;

        //Debug.Log($"currentTempoIndex: {currentTempoIndex}, tempoChangeTimes: {tempoChangeTimes}, spawnRatesForTempos: {spawnRatesForTempos}");

        // Check for tempo change
        if (currentTempoIndex < tempoChangeTimes.Length && Time.time >= tempoChangeTimes[currentTempoIndex])
        {
            spawnRate = spawnRatesForTempos[currentTempoIndex];
            currentTempoIndex++;
        }

        // Spawning logic with buffer consideration
        if (Time.time > nextSpawnTime && Time.time - lastSpawnTime > spawnBuffer)
        {
            SpawnPrompt();
            lastSpawnTime = Time.time;
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnPrompt()
    {
        // Randomly select one of the prefabs
        GameObject selectedPrefab = promptPrefabs[Random.Range(0, promptPrefabs.Length)];

        // Randomly select one of the spawn points
        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the randomly selected prefab at the randomly selected spawn point
        Instantiate(selectedPrefab, selectedSpawnPoint.position, Quaternion.identity);
    }
}
