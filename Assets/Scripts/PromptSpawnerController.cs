using UnityEngine;

public class PromptSpawnerController : MonoBehaviour
{
    public SpawnRateType currentSpawnRateType;

    [SerializeField] private float[] generalSpawnRates; // Array of spawn rates - 0: Slow, 1: Medium, 2: Fast

    [SerializeField] private GameObject[] promptPrefabs;  // Array of rhythmic prompt prefabs

    [SerializeField] private float spawnRate = 2.0f; // Initial spawn rate

    private float elapsedTime = 0f; // To track the time passed since the game started
    [SerializeField] private float slowDuration = 30f; // Duration for the 'Slow' spawn rate
    [SerializeField] private float mediumDuration = 30f; // Duration for the 'Medium' spawn rate
                                                         // The rest of the time until 90 seconds will be for 'Fast'

    private float nextSpawnTime = 0;
    private float lastSpawnTime = 0; // To keep track of the last spawn time
    private float spawnBuffer = 0.9f;  // Adjust this value as needed to ensure a buffer between spawns

    [Header("Tempo-based Spawn Rate Adjustments")]
    public float[] tempoChangeTimes; // The times (in seconds) when tempo changes
    public float[] spawnRatesForTempos; // The spawn rates for each tempo

    private int currentTempoIndex = 0; // To track which tempo we're currently on

    [SerializeField] private Transform[] spawnPoints; // Array of spawn points

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Check which spawn rate should be active
        if (elapsedTime <= slowDuration)
        {
            currentSpawnRateType = SpawnRateType.Slow;
        }
        else if (elapsedTime <= slowDuration + mediumDuration)
        {
            currentSpawnRateType = SpawnRateType.Medium;
        }
        else
        {
            currentSpawnRateType = SpawnRateType.Fast;
        }

        // Adjust the spawn rate based on the current spawn rate type
        spawnRate = generalSpawnRates[(int)currentSpawnRateType];

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
        // Randomly select one of the prefabs
        GameObject selectedPrefab = promptPrefabs[Random.Range(0, promptPrefabs.Length)];

        // Randomly select one of the spawn points
        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the randomly selected prefab at the randomly selected spawn point
        Instantiate(selectedPrefab, selectedSpawnPoint.position, Quaternion.identity);
    }

}
