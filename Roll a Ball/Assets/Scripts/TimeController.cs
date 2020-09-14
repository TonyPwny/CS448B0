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
