using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalSpawnPrefabs;

    public float spawnRangeX;
    public float spawnRangeZ;
    public float startDelay;
    public float spawnInterval;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        /*
         спаун по нажатию кнопки
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
        */
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-1,spawnRangeX), Random.Range(0,0), Random.Range(-spawnRangeZ, spawnRangeZ));
        int animalIndex = Random.Range(0, animalSpawnPrefabs.Length);
        Instantiate(animalSpawnPrefabs[animalIndex], spawnPos, animalSpawnPrefabs[animalIndex].transform.rotation);
    }
}
