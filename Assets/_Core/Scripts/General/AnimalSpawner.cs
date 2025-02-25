using UnityEngine;
using System.Collections;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs; // Массив префабов животных (Frog, Snake)
    [SerializeField] private float spawnIntervalMin = 1f; // Минимальный интервал спавна
    [SerializeField] private float spawnIntervalMax = 2f; // Максимальный интервал спавна
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

        // Выбираем случайное животное
        GameObject animalPrefab = animalPrefabs[Random.Range(0, animalPrefabs.Length)];

        // Генерируем случайную позицию на экране
        Vector3 spawnPosition = CameraBoundsHelper.GetRandomPointInBounds();

        // Создаем животное
        GameObject newAnimal = Instantiate(animalPrefab, transform);
        newAnimal.transform.position = spawnPosition;
    }


}
