using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject PausePanel;
    public GameObject ScoreHide;

    void Update()
    {
        pause();
    }
    public void exit()
    {
        Application.Quit();
    }
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   public void  pause()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
            ScoreHide.SetActive(false);
        }
    }
    public void resume()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        ScoreHide.SetActive(true);

    }
}
