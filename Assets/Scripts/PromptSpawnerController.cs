using UnityEngine;

public class PromptSpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject promptPrefab; // The rhythmic prompt prefab
    [SerializeField] private float spawnRate = 2.0f; // Initial spawn rate

    private float nextSpawnTime = 0;
    private float lastSpawnTime = 0; // To keep track of the last spawn time
    private float spawnBuffer = 0.5f;  // Adjust this value as needed to ensure a buffer between spawns

    [Header("Tempo-based Spawn Rate Adjustments")]
    public float[] tempoChangeTimes; // The times (in seconds) when tempo changes
    public float[] spawnRatesForTempos; // The spawn rates for each tempo

    private int currentTempoIndex = 0; // To track which tempo we're currently on

    [SerializeField] private Transform[] spawnPoints; // Array of spawn points

    void Update()
    {
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

    void SpawnPrompt()
    {
        // Randomly select one of the spawn points
        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the prompt at the selected spawn point
        Instantiate(promptPrefab, selectedSpawnPoint.position, Quaternion.identity);
    }
}
