using UnityEngine;

public class CloudSpawnner : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
    public float yMin = -4f;         // Minimum Y position
    public float yMax = 4f;          // Maximum Y position
    public float spawnX = 22f;        // Fixed X position
    public float initialSpawnInterval = 4f; // Initial time interval between spawns
    public float minSpawnInterval = 2f;   // Minimum time interval
    public float intervalDecreaseRate = 0.2f; // How quickly the interval decreases per spawn
    public float objectLifetime = 10f; // Time before the spawned object is destroyed

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

            // Decrease the spawn interval, clamped to the minimum value
            currentSpawnInterval = Mathf.Max(currentSpawnInterval - intervalDecreaseRate, minSpawnInterval);
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
        Destroy(spawnedObject, objectLifetime);

        Debug.Log($"Object spawned at: {spawnPosition}, Interval: {currentSpawnInterval}");
    }
}
