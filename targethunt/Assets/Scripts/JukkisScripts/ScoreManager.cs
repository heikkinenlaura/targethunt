using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public GameObject winScreen;

    public TextMeshProUGUI timerText;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            score++;
            if (score == 10)
            {
                winScreen.gameObject.SetActive(true);
                Time.timeScale = 0;
                timerText.text = "You got 10p. within: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<timer>().timerCount.ToString("0.00") + " seconds";
            }

        }
    }
}
