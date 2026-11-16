using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string firstSceneName = "Level1";
    public void PlayGame()
    {
        PlayerHealth.ResetSavedHealth();
        SceneManager.LoadScene(firstSceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
