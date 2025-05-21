using UnityEngine;

public class BeatManager : MonoBehaviour
{
    private AudioSource audioSource;
    public float bpm = 130f;
    public int currentBeat;

    public BeatmapSO beatmap;
    public static int CurrentBeatNumber { get; private set; }


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
        currentBeat = Mathf.FloorToInt(audioSource.time / beatInterval);
        CurrentBeatNumber = currentBeat;
        if (currentBeat != lastBeat)
        {
            lastBeat = currentBeat;
            OnBeat?.Invoke(currentBeat);
        }
    }
}
