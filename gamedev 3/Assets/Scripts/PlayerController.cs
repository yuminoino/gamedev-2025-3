using System.Runtime.CompilerServices;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;



            void OnCollisionEnter(Collision collision)
            {
                if (collision.gameObject.CompareTag("Obstacle"))
                {
                    Debug.Log("Hai colpito un ostacolo!");
                }
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
        { isOnGround = true;
            }
    }



