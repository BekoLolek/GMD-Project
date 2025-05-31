using UnityEngine;

public class PlayLevelManager : MonoBehaviour
{
    public GameObject audioManagerParent;

    public GameObject hellGate;
    private GameObject audioManagerInstance;

    private void Start()
    {
        if (LevelManager.Instance.SelectedLevel != null)
        {
            GameObject audioManagerPrefab = LevelManager.Instance.SelectedLevel.audioManagerPrefab;

            if (audioManagerPrefab != null)
            {
                audioManagerInstance = Instantiate(audioManagerPrefab, audioManagerParent.transform);
                hellGate.GetComponent<HellGate_Controller>().ToggleHellGate();
                //audioManagerInstance.GetComponent<AudioSource>().Play();
            }
            else
            {
                Debug.LogError("AudioManager prefab is not assigned in LevelDataSO.");
            }
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
