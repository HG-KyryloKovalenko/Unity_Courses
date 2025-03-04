using Unity.VisualScripting;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityModifier;
    private Rigidbody _playerRb;
    private Animator _animator;
    private AudioSource _playerAudio;
    public ParticleSystem DeathParticles;
    public ParticleSystem RunParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public bool canJump = true;
    public bool gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump && gameOver != true)
        {
            _playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            canJump = false; 
            _animator.SetTrigger("Jump_trig");
            RunParticles.Stop();
            _playerAudio.PlayOneShot(jumpSound, 1f); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            RunParticles.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
            DeathParticles.Play();
            RunParticles.Stop();
            _playerAudio.PlayOneShot(crashSound,1f);
        }
    }
}
