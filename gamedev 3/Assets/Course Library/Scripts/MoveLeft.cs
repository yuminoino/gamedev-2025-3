using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float initialSpeed = 5f;
    private float speedIncrease = 0.1f;

    private float maxSpeed = 30f;
    private PlayerController playerControllerScript;
    private float leftBound = -15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerControllerScript = GameObject.Find("Gino").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = initialSpeed + (speedIncrease * Time.time);
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }   
        
    }
}
