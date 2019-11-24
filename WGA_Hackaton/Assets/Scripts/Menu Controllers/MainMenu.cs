using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image _fadeEffectImg;

    private float _timeToStartTheGame = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _fadeEffectImg.gameObject.SetActive(true);
        _fadeEffectImg.canvasRenderer.SetAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        _fadeEffectImg.CrossFadeAlpha(1f, _timeToStartTheGame, false);
        StartCoroutine(StartGameCoroutine(_timeToStartTheGame));
    }

    public void LederboardScreen()
    {
        SceneManager.LoadScene("LeaderboardScreen");
    }

    IEnumerator StartGameCoroutine(float timeToStart)
    {
        yield return new WaitForSeconds(timeToStart);
        SceneManager.LoadScene("MainGame");
    }
}
