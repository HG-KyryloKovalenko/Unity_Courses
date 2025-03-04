using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSped;
    public GameObject onCollectEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.3f,rotationSped,0.2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the collectible
            Destroy(gameObject);

            // instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
       
    }
}
