using UnityEngine;
using UnityEngine.InputSystem;
using Game.Inputs;
public class RhythmInputManager : MonoBehaviour
{
    public Controls controls;

    
    public HitZone[] hitZones; // Drag your HitZone objects here
    public float hitWindow = 0.2f;
    public float bpm = 130f;
    private AudioSource audioSource;

    private float beatInterval;

    void Awake()
    {
        controls = new Controls();

        controls.Default.HitLeft.performed += ctx => OnLaneHit(0);
        controls.Default.HitMiddle.performed += ctx => OnLaneHit(1);
        controls.Default.HitRight.performed += ctx => OnLaneHit(2);
    }

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
    private void OnEnable()
    {
        controls.Default.Enable();
    }

    private void OnDisable()
    {
        controls.Default.Disable();
    }
    void OnLaneHit(int laneIndex)
    {
        float timeSinceLastBeat = audioSource.time % beatInterval;
                float timeToNextBeat = beatInterval - timeSinceLastBeat;
                float currentBeatTime = audioSource.time;

                bool onBeat = Mathf.Min(timeSinceLastBeat, timeToNextBeat) <= hitWindow;

                HitZone hitZone = hitZones[laneIndex];
                GameObject enemy = hitZone.GetTopEnemy();

                if (enemy != null)
                {
                    EnemyHealth health = enemy.GetComponent<EnemyHealth>();

                    if (health != null)
                    {
                        bool destroyed = health.RegisterHit(currentBeatTime, beatInterval, hitWindow);

                        if (onBeat && destroyed)
                        {
                            Debug.Log($"Perfect beat kill on lane {laneIndex}!");
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
                    Debug.Log($"No enemy on lane {laneIndex}.");
                    ScoreManager.Instance.RegisterMiss();
                }
    }

    

    bool IsOnBeat()
    {
        float timeSinceLastBeat = audioSource.time % beatInterval;
        float timeToNextBeat = beatInterval - timeSinceLastBeat;
        return Mathf.Min(timeSinceLastBeat, timeToNextBeat) <= hitWindow;
    }
}

