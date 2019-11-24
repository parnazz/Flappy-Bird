using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject _deathText;
    public Text _scoreText;

    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateScore(int points)
    {
        _scoreText.text = "Score: " + points;
        _score = points;
    }

    public void CalculateHighScore()
    {
        for (int i = 0; i < 5; i++)
        {
            if (_score > PlayerPrefs.GetInt("HighScore" + i, 0))
            {
                var temp = PlayerPrefs.GetInt("HighScore" + i, 0);
                PlayerPrefs.SetInt("HighScore" + i, _score);
                _score = temp;
            }
        }
    }

    public void ShowMessageOnDeath()
    {
        _deathText.gameObject.SetActive(true);
    }
}
