using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardMenu : MonoBehaviour
{
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
