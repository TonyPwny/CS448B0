// Anthony Tiongson (ast119)
// List of resources used:
// https://answers.unity.com/questions/1417767/c-how-to-check-if-player-is-grounded.html
// https://answers.unity.com/questions/1261937/creating-a-restart-button.html
// https://answers.unity.com/questions/1275232/disable-all-inputs.html
// https://answers.unity.com/questions/1400361/how-to-create-a-border-around-2d-text.html
// https://answers.unity.com/questions/885849/how-to-respawn-with-a-simple-delay.html
// https://gamedev.stackexchange.com/questions/151670/unity-how-to-detect-collision-occuring-on-child-object-from-a-parent-script
// https://learn.unity.com/tutorial/fps-mod-customize-the-sky
// https://learn.unity.com/project/roll-a-ball-tutorial
// https://www.youtube.com/watch?v=qc7J0iei3BU

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public string playerNumber;
    public Text scoreText;

    private Rigidbody rb;
    private int score;
    private int bonus;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        bonus = 0;
        scoreText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeController.instance.ElapsedSeconds() >= 10)
        {
            bonus = (TimeController.instance.ElapsedSeconds() / 10) + 1;
        }
    }
    
    // FixedUpdate is called just before performing any physics calculations
    void FixedUpdate()
    {
        if (GameController.inPlay)
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

    // Increments score whenever the player touches any Pick Ups
    void OnTriggerEnter(Collider collision)
    {
        if (GameController.inPlay)
        {
            if (collision.gameObject.CompareTag("Pick Up") && GameController.inPlay)
            {
                IncremenentScore();
            }
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

        if (GameController.inPlay)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                DecrementScore();
            }

            if (collision.gameObject.CompareTag("Player") && (transform.position.y < (collision.transform.position.y - 0.01)))
            {
                DecrementScore();
            }
        }
    }

    void DecrementScore()
    {
        if (score > 0)
        {
            score--;
            SetScoreText();
        }
    }

    void IncremenentScore()
    {
        if (TimeController.instance.ElapsedSeconds() >= 10)
        {
            score = score + bonus;
        }
        else
        {
            score++;
        }
        SetScoreText();
    }

    public void SetScoreText()
    {
        scoreText.text = "P" + playerNumber + " Score: " + score.ToString();
    }

    public int MyScore()
    {
        return score;
    }
}
