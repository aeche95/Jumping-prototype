using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private Rigidbody rb;
    Animator anim;
    bool isGrounded = true;
    public AudioClip jumpClip;
    public AudioClip crashSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        audioSource = GetComponent<AudioSource>();
        GameManager.Instance.resetEvent.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !GameManager.Instance.gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
            anim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpClip);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticle.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.gameOver = true;
            anim.SetBool("Death_b", true);
            dirtParticle.Stop();
            anim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            audioSource.PlayOneShot(crashSound);
        }
        
    }

    void Restart()
    {
        transform.position = new Vector3 (0, 0, 0);
        anim.SetTrigger("Restart");
    }
}
