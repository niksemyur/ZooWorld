using UnityEngine;
using System.Collections;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs; // ������ �������� �������� (Frog, Snake)
    [SerializeField] private float spawnIntervalMin = 1f; // ����������� �������� ������
    [SerializeField] private float spawnIntervalMax = 2f; // ������������ �������� ������
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

        // �������� ��������� ��������
        GameObject animalPrefab = animalPrefabs[Random.Range(0, animalPrefabs.Length)];

        // ���������� ��������� ������� �� ������
        Vector3 spawnPosition = CameraBoundsHelper.GetRandomPointInBounds();

        // ������� ��������
        GameObject newAnimal = Instantiate(animalPrefab, transform);
        newAnimal.transform.position = spawnPosition;
    }


}
