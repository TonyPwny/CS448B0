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
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text promptText;
    public Text gameRulesText;
    public Text controlsP1Text;
    public Text controlsP2Text;
    public Text gameOverText;
    public PlayerController playerOne;
    public PlayerController playerTwo;
    public int timeLimit;
    public static bool inPlay = false;

    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameRulesText.text = "Roll A Ball Deluxe" + "\n" +
            "The time limit is set to " + timeLimit + " min." + "\n" +
            "Golden cubes are worth points and will respawn after 10 seconds." + "\n" +
            "Every 10 seconds, golden cubes gain an additional point of value." + "\n" +
            "Colliding with walls will deduct a point." + "\n" +
            "Colliding with the opponent at a higher height reduces their points!" + "\n" +
            "Falling is an instant disqualification!"; 
        promptText.text = "Press Enter/Return to Begin";
        controlsP1Text.text = "P1 Uses W, S, A, D to Move\nSpacebar to Jump";
        controlsP2Text.text = "P2 Uses Arrow Keys to Move\nRight Shift to Jump";
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Submit") && !inPlay && !gameOver)
        {
            promptText.text = "Press Esc to Start Over";
            gameRulesText.text = "";
            controlsP1Text.text = "";
            controlsP2Text.text = "";
            playerOne.SetScoreText();
            playerTwo.SetScoreText();
            TimeController.instance.BeginTimer();
            inPlay = true;
        }

        if (Input.GetButton("Cancel"))
        {
            inPlay = false;
            gameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (playerOne.transform.position.y < -5 && playerTwo.transform.position.y >= -5)
        {
            inPlay = false;
            gameOver = true;
            gameOverText.text = "P1 has fallen!" + "\nP2 wins!";
        }
        else if (playerTwo.transform.position.y < -5 && playerOne.transform.position.y >= -5)
        {
            inPlay = false;
            gameOver = true;
            gameOverText.text = "P2 has fallen!" + "\nP1 wins!";
        }

        if (TimeController.instance.Minutes() >= timeLimit)
        {
            inPlay = false;
            gameOver = true;

            if (playerOne.MyScore() > playerTwo.MyScore())
            {
                gameOverText.text = "P1 is victorious!";
            }
            else if (playerOne.MyScore() < playerTwo.MyScore())
            {
                gameOverText.text = "P2 is victorious!";
            }
            else
            {
                gameOverText.text = "Stalemate!" + "\n" + "Rematch?";
            }
        }
    }
}
