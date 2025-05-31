using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject levelSelectPanel;
    public GameObject optionsPanel;
    public GameObject mainMenuPanel;

    public GameObject leaderboardPanel;

    public void OnPlayPressed()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
        optionsPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }

    public void OnLeaderboardPressed()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        optionsPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
    }

    public void OnOptionsPressed()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }

    public void OnQuitPressed()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // For editor testing
    }

    // Optional: Go back to main menu
    public void OnBackToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
        optionsPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }
}
