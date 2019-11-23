using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject _deathText;
    public Text _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateScore(int points)
    {
        _scoreText.text = "Score: " + points;
    }

    public void ShowMessageOnDeath()
    {
        _deathText.gameObject.SetActive(true);
    }
}
