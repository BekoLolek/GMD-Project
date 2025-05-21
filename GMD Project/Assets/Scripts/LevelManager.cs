using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public LevelDataSO SelectedLevel { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void SetSelectedLevel(LevelDataSO level)
    {
        SelectedLevel = level;

        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayScene");
    }
}
