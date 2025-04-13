using UnityEngine;

public class FeatherSpawnner : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
    public float yMin = -3f;         // Minimum Y position
    public float yMax = 3f;          // Maximum Y position
    public float spawnX = 8f;        // Fixed X position
    public float initialSpawnInterval = 2f; // Initial time interval between spawns
    public float maxSpawnInterval = 5f;   // Maximum time interval
    public float intervalIncreaseRate = 0.1f; // How quickly the interval increases per spawn
    public float objectLifetime = 5f;       // Time before the spawned object is destroyed

    private float currentSpawnInterval; // Current interval
    private float spawnTimer;

    void Start()
    {
        // Initialize the spawn interval
        currentSpawnInterval = initialSpawnInterval;
    }

    void Update()
    {
        // Increment the timer
        spawnTimer += Time.deltaTime;

        // Spawn object when the timer reaches the current interval
        if (spawnTimer >= currentSpawnInterval)
        {
            SpawnObject();
            spawnTimer = 0f; // Reset the timer

            // Increase the spawn interval, clamped to the maximum value
            currentSpawnInterval = Mathf.Min(currentSpawnInterval + intervalIncreaseRate, maxSpawnInterval);
        }
    }

    void SpawnObject()
    {
        // Generate a random Y position within the range
        float randomY = Random.Range(yMin, yMax);

        // Set the spawn position (same X, random Y, and 0 Z)
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);

        // Instantiate the object
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Destroy the object after its lifetime expires
        Destroy(spawnedObject, objectLifetime);

        Debug.Log($"Object spawned at: {spawnPosition}, Interval: {currentSpawnInterval}");
    }
}
