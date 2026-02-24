using UnityEngine;
using TMPro;


public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    float score;
    float highScore;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D RB;

    public TMP_Text ScoreTxt;
    public TMP_Text HighScoreTxt;


    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;

        // Shows the high score, but if there's no high score then it's 0
        //Original Code: highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScore = 0;
        HighScoreTxt.text = "High Score: " + highScore.ToString("F");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if(isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "Score: " + score.ToString("F");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            isAlive = false;
            CheckHighScore();
            Time.timeScale = 0;
        }
    }

    // Checks high score when the player dies
    void CheckHighScore() {
        if (score > highScore) {
            highScore = score;

            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
            HighScoreTxt.text = "High Score: " + highScore.ToString("F");
        }
    }
}
