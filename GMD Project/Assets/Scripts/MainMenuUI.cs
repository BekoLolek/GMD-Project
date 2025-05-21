using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject levelSelectPanel;
    public GameObject optionsPanel;
    public GameObject mainMenuPanel;

    public void OnPlayPressed()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void OnOptionsPressed()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
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
    }
}
