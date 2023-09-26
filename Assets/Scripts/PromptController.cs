using UnityEngine;

public class PromptController : MonoBehaviour
{
    [SerializeField] private GameObject promptPrefab; // The rhythmic prompt prefab
    [SerializeField] private float spawnRate = 2.0f; // Time in seconds between spawns    
   
    private float nextSpawnTime = 0;

    // Define the boundaries for the random X position
    [SerializeField] private float minX = -2.5f; // Adjust based on your screen size and preference
    [SerializeField] private float maxX = 2.5f; // Adjust based on your screen size and preference

  

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnPrompt();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnPrompt()
    {
        // Generate a random X position within the defined boundaries
        float randomX = Random.Range(minX, maxX);

        // Use the random X for the spawn position
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(promptPrefab, spawnPosition, Quaternion.identity);
    }
}
