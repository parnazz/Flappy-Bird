using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardMenu : MonoBehaviour
{
    public Text[] highScoreTexts;

    public static int numberOfHighScores;

    private void Start()
    {
        numberOfHighScores = highScoreTexts.Length;

        //Если нужно сбросить счёт
        //ResetScore();

        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            highScoreTexts[i].text = (i + 1) + ". High Score: " + PlayerPrefs.GetInt("HighScore" + i, 0);
        }
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //private void ResetScore()
    //{
    //    for (int i = 0; i < numberOfHighScores; i++)
    //    {
    //        PlayerPrefs.DeleteKey("HighScore" + i);
    //    }
    //}
}
