using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPrefab;
    private Vector3 _spawnPosition = new Vector3(37, 0, 0);
    private float _startDelay = 2f;
    private float _timer = 2f;
    private PlayerContoller playerContollerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerContollerScript = GameObject.Find("Player").GetComponent<PlayerContoller>();
        InvokeRepeating("SpawnObstacle", _startDelay, _timer);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacle()
    {
        if (playerContollerScript.gameOver == false)
        {
            Instantiate(spawnPrefab, _spawnPosition, spawnPrefab.transform.rotation);
        }
    }
}
