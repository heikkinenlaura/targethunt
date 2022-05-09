using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject panel;
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }
    public void ReplayGame()
    {

    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
