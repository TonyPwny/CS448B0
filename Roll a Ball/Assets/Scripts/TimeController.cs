// Anthony Tiongson (ast119)
// https://learn.unity.com/project/roll-a-ball-tutorial
// https://answers.unity.com/questions/1417767/c-how-to-check-if-player-is-grounded.html
// https://answers.unity.com/questions/1275232/disable-all-inputs.html
// https://answers.unity.com/questions/1261937/creating-a-restart-button.html
// https://www.youtube.com/watch?v=qc7J0iei3BU

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{

    public static TimeController instance;
    public Text gameTimerText;

    private TimeSpan gameTimer;
    private bool timerOn;
    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameTimerText.text = "";
        timerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.inPlay)
        {
            timerOn = false;
        }
    }

    public void BeginTimer()
    {
        timerOn = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerOn = false;
    }

    public int Minutes()
    {
        return gameTimer.Minutes;
    }

    public int ElapsedSeconds()
    {
        return (int) elapsedTime;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerOn)
        {
            elapsedTime += Time.deltaTime;
            gameTimer = TimeSpan.FromSeconds(elapsedTime);
            string gameTime = gameTimer.ToString("mm':'ss'.'ff");
            gameTimerText.text = gameTime;

            yield return null;
        }
    }
}
