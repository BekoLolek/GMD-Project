using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatManager : MonoBehaviour
{
    private AudioSource audioSource;
    public float bpm = 130f;
    public int currentBeat;

    public static int CurrentBeatNumber { get; private set; }

    public LevelDataSO levelData;


    public static event System.Action<int> OnBeat;

    private float beatInterval;
    private int lastBeat = -1;

    
    void Start()
    {
        PlayLevelManager lm = FindFirstObjectByType<PlayLevelManager>();
        if (lm != null)
        {
            audioSource = lm.GetAudioManager();
            if (audioSource == null)
            {
                Debug.LogError("AudioManager not found!");
            }
        }

        var selectedLevel = LevelManager.Instance.SelectedLevel;

        if (selectedLevel != null)
        {
            Debug.Log("Loading level: " + selectedLevel.levelName);
            bpm = selectedLevel.bpm;
            beatInterval = 60f / bpm;
            
        }
    }


    void Update()
    {
        if (audioSource == null)
            return;

        if (audioSource.isPlaying)
        {
            currentBeat = Mathf.FloorToInt(audioSource.time / beatInterval);
            CurrentBeatNumber = currentBeat;
            if (currentBeat != lastBeat)
            {
                lastBeat = currentBeat;
                OnBeat?.Invoke(currentBeat);
            }
        }
        else if (audioSource.time >= audioSource.clip.length)
        {
            ScoreSubmitter.SubmitScore(GetRandomString(), ScoreManager.Instance.score, levelData);
            Debug.Log($"Level completed. Score submitted. {ScoreManager.Instance.score} for {levelData.levelName}");
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    private string GetRandomString()
    {
        string[] options = { "Lolek", "Jake", "Kasper", "Rojus", "Nerijus" };
        int index = Random.Range(0, options.Length);
        return options[index];
    }
}
