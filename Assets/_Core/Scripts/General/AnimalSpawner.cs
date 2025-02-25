using UnityEngine;
using System.Collections;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs; // Array of animal prefabs
    [SerializeField] private float spawnIntervalMin = 1f; // Minimum spawn interval
    [SerializeField] private float spawnIntervalMax = 2f; // Maximum spawn interval
    void Start()
    {
        StartCoroutine(SpawnAnimals());
    }

    private IEnumerator SpawnAnimals()
    {
        while (true)
        {
            SpawnAnimal();
            float interval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(interval);
        }
    }

    private void SpawnAnimal()
    {
        if (animalPrefabs.Length == 0) return;

        // Choose a random animal
        GameObject animalPrefab = animalPrefabs[Random.Range(0, animalPrefabs.Length)];

        // Generate a random position in bounds
        Vector3 spawnPosition = CameraBoundsHelper.GetRandomPointInBounds();

        // Spawn animal
        GameObject newAnimal = Instantiate(animalPrefab, transform);
        newAnimal.transform.position = spawnPosition;
    }


}
