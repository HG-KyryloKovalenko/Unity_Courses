using UnityEngine;
using System.Collections;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody _rb;
    private GameObject _focalPoint;
    private float _powerUpStrength = 15f;
    public GameObject powerUpIndicator;
    public bool hasPowerUp = false;
    public float playerSpeed;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        float forward = Input.GetAxis("Vertical");
        _rb.AddForce(_focalPoint.transform.forward * forward * playerSpeed);
       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Debug.Log("PowerUp Activated");
            StartCoroutine(PowerUpCoundownRoutine());
        }
    }

    IEnumerator PowerUpCoundownRoutine()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("PowerUp Deactivated");
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemeyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.transform.position - transform.position;
            
            enemeyRB.AddForce(awayFromPlayer * _powerUpStrength, ForceMode.Impulse);
            Debug.Log("Colided with: " + collision.gameObject.name + "with PowerUp set to " + hasPowerUp);
        }
    }
}
