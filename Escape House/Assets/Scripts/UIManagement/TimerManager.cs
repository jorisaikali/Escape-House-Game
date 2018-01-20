using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    public Text timerText;
    public int startMinutes;
    public int startSeconds;

    private float startTime;
    private float t;

    void Start()
    {
        startTime = (startMinutes * 60) + startSeconds;
    }

    void Update()
    {
        t = startTime - Time.time;

        timerText.text = FormatTime(t);
    }

    string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = ((time * 100) % 100);
        string timeText = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
        return timeText;
    }

    public bool IsTimeUp()
    {
        if (t <= 0f)
        {
            // Do something
            Debug.Log("Time is up!");
            return true;
        }

        return false;
    }

    public void DecreaseTimer(float dec)
    {
        startTime -= dec;
    }
}
