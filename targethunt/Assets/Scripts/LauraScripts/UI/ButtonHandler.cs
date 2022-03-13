using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        Time.timeScale = 1;
    }
}
