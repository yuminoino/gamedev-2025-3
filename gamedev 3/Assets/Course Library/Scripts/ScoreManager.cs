using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;
    public PlayerController Gino;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Gino.score;
        if (Gino.gameOver)
        {
            gameOver.SetActive(true);
            Destroy(this);
        }
    }
}
