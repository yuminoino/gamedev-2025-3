using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float jumpForce = 11.0f;
    private Animator playerAim;
    public AudioSource playerAudio;

    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public int score = 0;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);

            // Aumenta il punteggio ad ogni salto
            score ++;
            Debug.Log("Score: " + score);
            dirtParticle.Stop();

        }
        else if (gameOver)
        {
            playerAim.SetBool("Death_b", true);
            playerAim.SetInteger("DeathType_int", 1);
        }
    }

    private void OnCollisionEnter(Collision collision) 

        { 
        
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true; 
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        Debug.Log("Game Over!");
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
   }
}





