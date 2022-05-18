using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public GameObject winScreen;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            score++;
            if (score == 10)
            {
                winScreen.gameObject.SetActive(true);
            }
            Debug.Log("Voitit pelin");

        }
    }
}
