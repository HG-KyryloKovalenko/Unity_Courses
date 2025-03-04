using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnEnemyPrefab;
    public GameObject spawnPowerUpPrefab;
    private float spawnRange = 9.0f;
    private int _enemiesCount;
    private int _waveNumber = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spawnEnemyWave(_waveNumber);
        Instantiate(spawnPowerUpPrefab, _GenerateSpawnPoint(),spawnPowerUpPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        _enemiesCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if (_enemiesCount == 0)
        {
            _waveNumber++;
            _spawnEnemyWave(_waveNumber);
            SpawnPowerUp();
        }
    }

    void SpawnPowerUp()
    {
        Instantiate(spawnPowerUpPrefab, _GenerateSpawnPoint(),spawnPowerUpPrefab.transform.rotation);
    }
    void _spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn;i++)
        {
            Instantiate(spawnEnemyPrefab, _GenerateSpawnPoint(), spawnEnemyPrefab.transform.rotation);
        }

    }

    private Vector3 _GenerateSpawnPoint()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return spawnPosition;
    }


}
