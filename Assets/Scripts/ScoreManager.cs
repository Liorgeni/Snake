using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score;


    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        UIController.Instance.UpdateScoreDisplay(score);

    }

    public void UpdateScore()
    {
        score--;


        if (score <= 0)
        {
            Snake.instance.isGameOver = true;
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                StartCoroutine(LoadLevelAfterDelay("level 2", 1.0f));

            }else if (SceneManager.GetActiveScene().buildIndex == 2)
            { 
                    UIController.Instance.ShowVictoryScreen();
            }
        }
    }

    private IEnumerator LoadLevelAfterDelay(string levelName, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(levelName);
    }

}
