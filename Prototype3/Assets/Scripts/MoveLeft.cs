using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _moveSpeed = 25f;
    private PlayerContoller playerContollerScript;

    private float _leftBound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerContollerScript = GameObject.Find("Player").GetComponent<PlayerContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerContollerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        }

        if (transform.position.x < _leftBound && gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
