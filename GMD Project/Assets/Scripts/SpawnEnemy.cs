using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour
{
    public BeatmapSO beatmap;
    public GameObject[] laneSpawns;
    public GameObject enemyPrefab;

    public GameObject doubleHitEnemyPrefab;
    public AudioSource audioSource;

    public int skipBeats = 4;

    private int currentIndex = 0;

    private List<BeatEvent> beatEvents;


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
            beatmap = selectedLevel.beatmap;
        }
        audioSource.Play();
    }

    void OnEnable()
    {
        BeatManager.OnBeat += HandleBeat;
    }

    void OnDisable()
    {
        BeatManager.OnBeat -= HandleBeat;
    }

    void HandleBeat(int beatNumber)
    {
        beatNumber -= skipBeats;
        if (beatmap.events.Count > currentIndex && beatNumber >= 0)
        {
            BeatEvent next = beatmap.events[currentIndex];
            if (beatNumber == next.beatNumber)
            {
                if (beatNumber == beatmap.events[currentIndex + 1].beatNumber)
                {
                    if (beatmap.events[currentIndex + 1].type == 0)
                    {
                        Vector3 spawnPos2 = laneSpawns[beatmap.events[currentIndex + 1].lane].transform.position;
                        Instantiate(enemyPrefab, spawnPos2, Quaternion.identity);
                        currentIndex++;
                    }
                    else if (beatmap.events[currentIndex + 1].type == 1)
                    {
                        Vector3 spawnPos2 = laneSpawns[beatmap.events[currentIndex + 1].lane].transform.position;
                        Instantiate(doubleHitEnemyPrefab, spawnPos2, Quaternion.identity);
                        currentIndex++;
                    }

                }

                if (next.type == 0)
                {
                    Vector3 spawnPos = laneSpawns[next.lane].transform.position;
                    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                    currentIndex++;
                }
                else if (next.type == 1)
                {
                    Vector3 spawnPos = laneSpawns[next.lane].transform.position;
                    Instantiate(doubleHitEnemyPrefab, spawnPos, Quaternion.identity);
                    currentIndex++;
                }

            }
        }

    }


}
