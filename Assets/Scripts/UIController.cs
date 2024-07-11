using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public GameObject gameOverScreen;
    public GameObject vicrotyScreen;
    public TMP_Text scoreNumber;
    public TMP_Text levelNumber;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateLevelDisplay();

    }


    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }
        public void ShowVictoryScreen()
    {
        vicrotyScreen.SetActive(true);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void UpdateScoreDisplay(int score)
    {
        scoreNumber.text = score.ToString();
    }
        public void UpdateLevelDisplay()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        levelNumber.text = level.ToString();
    }




    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
