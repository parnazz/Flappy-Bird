using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool isGameActive = false;
    public GameObject leaderboardScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
        isGameActive = true;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void LederboardScreen()
    {
        gameObject.SetActive(false);
        leaderboardScreen.gameObject.SetActive(true);
    }
}
