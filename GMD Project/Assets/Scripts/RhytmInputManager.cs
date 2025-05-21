using UnityEngine;
public class RhythmInputManager : MonoBehaviour
{
    public KeyCode[] laneKeys = new KeyCode[3] { KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightArrow };
    public HitZone[] hitZones; // Drag your HitZone objects here
    public float hitWindow = 0.2f;
    public float bpm = 130f;
    private AudioSource audioSource;

    private float beatInterval;

    void Start()
    {
        beatInterval = 60f / bpm;

        PlayLevelManager lm = FindFirstObjectByType<PlayLevelManager>();
        if (lm != null)
        {
            audioSource = lm.GetAudioManager();
            if (audioSource == null)
            {
                Debug.LogError("AudioManager not found!");
            }
        }
    }

    void Update()
    {
        for (int lane = 0; lane < laneKeys.Length; lane++)
        {
            if (Input.GetKeyDown(laneKeys[lane]))
            {
                float timeSinceLastBeat = audioSource.time % beatInterval;
                float timeToNextBeat = beatInterval - timeSinceLastBeat;
                float currentBeatTime = audioSource.time;

                bool onBeat = Mathf.Min(timeSinceLastBeat, timeToNextBeat) <= hitWindow;

                HitZone hitZone = hitZones[lane];
                GameObject enemy = hitZone.GetTopEnemy();

                if (enemy != null)
                {
                    EnemyHealth health = enemy.GetComponent<EnemyHealth>();

                    if (health != null)
                    {
                        bool destroyed = health.RegisterHit(currentBeatTime, beatInterval, hitWindow);

                        if (onBeat && destroyed)
                        {
                            Debug.Log($"Perfect beat kill on lane {lane}!");
                            ScoreManager.Instance.RegisterPerfectHit();
                            hitZone.DestroyEnemy();
                        }
                        else if (onBeat)
                        {
                            Debug.Log($"First beat hit on tough enemy.");
                            ScoreManager.Instance.RegisterPerfectHit();
                        }
                        else if (destroyed)
                        {
                            Debug.Log($"Off-beat follow-up, enemy destroyed.");
                            ScoreManager.Instance.RegisterPerfectHit();
                            hitZone.DestroyEnemy();
                        }
                        else
                        {
                            Debug.Log($"Off-beat hit ignored.");
                            ScoreManager.Instance.RegisterMiss();
                        }
                    }
                }
                else
                {
                    Debug.Log($"No enemy on lane {lane}.");
                    ScoreManager.Instance.RegisterMiss();
                }
            }

        }
    }

    bool IsOnBeat()
    {
        float timeSinceLastBeat = audioSource.time % beatInterval;
        float timeToNextBeat = beatInterval - timeSinceLastBeat;
        return Mathf.Min(timeSinceLastBeat, timeToNextBeat) <= hitWindow;
    }
}

