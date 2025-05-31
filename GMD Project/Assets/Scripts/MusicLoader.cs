using UnityEngine;
using System.Collections;

public class MusicLoader : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject loadingScreen;

    public ScoreManager scoreManager;

    void Start()
    {
        StartCoroutine(WaitForAudioSourceToLoad());

    }

    IEnumerator WaitForMusicStart()
    {

        while (!audioSource.isPlaying)
        {
            yield return null;
        }
        loadingScreen.SetActive(false);
        ScoreManager.isStarted = true;
    }

    IEnumerator WaitForAudioSourceToLoad()
    {
        while (audioSource == null)
        {
            PlayLevelManager lm = FindFirstObjectByType<PlayLevelManager>();
            if (lm != null)
            {
                audioSource = lm.GetAudioManager();
                audioSource.Play();
                scoreManager.startScoring();
                Debug.Log("Playing music");
            }
            yield return null;
        }


        StartCoroutine(WaitForMusicStart());
    }
}
