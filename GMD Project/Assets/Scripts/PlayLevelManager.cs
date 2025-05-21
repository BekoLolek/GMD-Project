using UnityEngine;

public class PlayLevelManager : MonoBehaviour
{
    public GameObject audioManagerParent;

    private GameObject audioManagerInstance;

    private void Start()
    {
        if (LevelManager.Instance.SelectedLevel != null)
        {
            GameObject audioManagerPrefab = LevelManager.Instance.SelectedLevel.audioManagerPrefab;

            if (audioManagerPrefab != null)
            {
                audioManagerInstance = Instantiate(audioManagerPrefab, audioManagerParent.transform);
            }
            else
            {
                Debug.LogError("AudioManager prefab is not assigned in LevelDataSO.");
            }
        }
        else
        {
            Debug.LogError("No LevelDataSO selected. Make sure you set SelectedLevel.currentLevel before loading the scene.");
        }
    }

    public AudioSource GetAudioManager()
    {
        if (audioManagerInstance != null)
            return audioManagerInstance.GetComponent<AudioSource>();

        var am = audioManagerParent.GetComponentInChildren<AudioSource>();
        if (am != null)
            audioManagerInstance = am.gameObject;

        return am;
    }
}
