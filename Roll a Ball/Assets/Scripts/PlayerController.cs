// Anthony Tiongson
// https://learn.unity.com/project/roll-a-ball-tutorial
// https://answers.unity.com/questions/1417767/c-how-to-check-if-player-is-grounded.html
// https://answers.unity.com/questions/1275232/disable-all-inputs.html
// https://answers.unity.com/questions/1261937/creating-a-restart-button.html


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool inPlay = false;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public string playerNumber;
    public string otherPlayer;
    public Text scoreText;
    public Text promptText;
    public Text gameOverText;

    private Rigidbody rb;
    private int score;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        if (playerNumber.Equals("1"))
        {
            scoreText.text = "P" + playerNumber + ": W,S,A,D to Move, Spacebar to Jump";
        }
        else
        {
            scoreText.text = "P" + playerNumber + ": Arrows to Move, Right Shift to Jump";
        }
        
        promptText.text = "Press Enter/Return to Begin";
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetButton("Submit"))
        {
            SetScoreText();
            promptText.text = "Press Esc to Start Over";
            GameManager.inPlay = true; //enables all inputs
        }

        if (rb.transform.position.y < -5)
        {
            gameOverText.text = "P" + playerNumber + " has fallen!" + "\nP" + otherPlayer + " wins!";
        }

    }
    
    // FixedUpdate is called just before performing any physics calculations
    void FixedUpdate()
    {
        if (GameManager.inPlay)
        {
            float moveHorizontal = Input.GetAxis(playerNumber + "_Horizontal");
            float moveVertical = Input.GetAxis(playerNumber + "_Vertical");


            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            if (Input.GetButton(playerNumber + "_Jump") && isGrounded)
            {
                movement.Set(moveHorizontal, jumpPower, moveVertical);
            }

            rb.AddForce(movement * speed);
        }
    }

    // Deactivates Pick Ups that the player touches
    void OnTriggerEnter(Collider pickUp)
    {
        if (pickUp.gameObject.CompareTag("Pick Up"))
        {
            pickUp.gameObject.SetActive(false);
            score += 1;
            SetScoreText();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    void SetScoreText()
    {
        scoreText.text = "P" + playerNumber + " Score: " + score.ToString();

        if (score >= 12)
        {
            gameOverText.text = "You Win!";
        }
    }
}
