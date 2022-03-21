using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public float timerCount = 0.0f;
    public int seconds;
    public TMP_Text text;

    void Update()
    {
        // seconds in float
        timerCount += Time.deltaTime;
        // turn seconds in float to int
        seconds = (int)(timerCount % 60);
        text.text = "Time " + (seconds);
    }
}
