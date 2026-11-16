using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private string firstSceneName = "Level1";
    [SerializeField] private string menuSceneName = "MainMenu";
    public void ShowLose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ShowWin()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartLevel()
    {
        PlayerHealth.ResetSavedHealth();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RestartGame()
    {
        PlayerHealth.ResetSavedHealth();
        Time.timeScale = 1f;
        SceneManager.LoadScene(firstSceneName);
    }
    private void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}
