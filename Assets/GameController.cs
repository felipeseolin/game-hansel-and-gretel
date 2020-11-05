using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int candies = 0;
    public static bool pcIsDead = false;
    public static bool gameIsPause = false;
    public static int numberOfLifes = 3;
    public static bool IsPowerdUp = false;
    public static float PowerUpTotalTime = 15f;
    public static float PowerUpTimeLeft = 15f;

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject gamePanel;
    public GameObject candiesContainer;
    public GameObject powerUpsContainer;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        GameOver();
        PowerUpCounter();
        ActivatePowerUps();
    }

    private void ActivatePowerUps()
    {
        if (candies % candiesContainer.transform.childCount == 0)
        {
            // Activate all candies
            for (int i = 0; i < candiesContainer.transform.childCount; i++)
                candiesContainer.transform.GetChild(i).gameObject.SetActive(true);
            // Activate all power-ups
            for (int i = 0; i < powerUpsContainer.transform.childCount; i++)
                powerUpsContainer.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void ResetGame()
    {
        candies = 0;
        pcIsDead = false;
        gameIsPause = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
        IsPowerdUp = false;
        PowerUpTimeLeft = PowerUpTotalTime;
        ActiveGamePanel();
    }

    private void PowerUpCounter()
    {
        if (!IsPowerdUp)
        {
            PowerUpTimeLeft = PowerUpTotalTime;
            return;
        }

        if (PowerUpTimeLeft < 0f)
        {
            IsPowerdUp = false;
            PowerUpTimeLeft = PowerUpTotalTime;
        }

        PowerUpTimeLeft -= Time.deltaTime;
    }

    public static void SetPowerdUp(bool value = true)
    {
        if (value)
        {
            IsPowerdUp = true;
            PowerUpTimeLeft -= Time.deltaTime;
            if (PowerUpTimeLeft < 0f)
            {
                IsPowerdUp = false;
                PowerUpTimeLeft = PowerUpTotalTime;
            }
        }
        else
        {
            IsPowerdUp = false;
            PowerUpTimeLeft = PowerUpTotalTime;
        }
    }

    public static void IncreaseCandy()
    {
        candies++;
    }

    public static void PcHasDead()
    {
        pcIsDead = true;
    }

    public void GameOver()
    {
        if (!pcIsDead)
            return;
        // Game over or not?
        numberOfLifes--;
        if (numberOfLifes <= 0)
        {
            // Lifes is over
            Cursor.visible = true;
            Time.timeScale = 0;
            numberOfLifes = 3;
            ActiveGameOverPanel();
            pcIsDead = false;
        }
        else
        {
            pcIsDead = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                gameIsPause = false;
                Cursor.visible = false;
                ResumeGame();
                ActiveGamePanel();
            }
            else
            {
                Cursor.visible = true;
                Time.timeScale = 0;
                gameIsPause = true;
                ActivePausePanel();
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        ActiveGamePanel();
    }

    public void NewGame()
    {
        ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void ActiveGamePanel()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    private void ActiveGameOverPanel()
    {
        gamePanel.SetActive(false);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    private void ActivePausePanel()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}