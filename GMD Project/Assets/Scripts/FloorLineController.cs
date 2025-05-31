using UnityEngine;
using System.Collections;

public class FloorLineController : MonoBehaviour
{
    private Renderer rend;

    private BeatManager beatManager;

    private float _bpm;
    private int _beatNumber;

    private bool started = false;
    public float moveDelay = 0.2f;


    void Start()
    {
        rend = GetComponent<Renderer>();
        PlayLevelManager lm = FindFirstObjectByType<PlayLevelManager>();
        if (lm != null)
        {
            beatManager = lm.GetAudioManager().GetComponent<BeatManager>();
        }
        _bpm = beatManager.bpm;
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
        _beatNumber = beatNumber;
        if (!started)
        {
            StartCoroutine(AnimateDelayed(beatNumber));
        }

    }

    IEnumerator LineAnimation(int beatNumber)
    {
        float beatDuration = 60f / _bpm;

        // 1. Decrease frequency from 100 to 0 over 0.2s
        float decayTime = 0.15f;
        float startTime = Time.time;
        while (Time.time < startTime + decayTime)
        {
            float t = (Time.time - startTime) / decayTime;
            float frequency = Mathf.Lerp(0.4f, 0f, t);
            rend.material.SetFloat("_LineMorph", frequency);
            yield return null;
        }

        // 2. Wait until 0.2s before the next beat
        float waitTime = beatDuration - 0.3f;
        if (waitTime > 0f)
            yield return new WaitForSeconds(waitTime);

        // 3. Increase from 0 to 100 over 0.2s before next beat
        float riseTime = 0.15f;
        float riseStartTime = Time.time;
        while (Time.time < riseStartTime + riseTime)
        {
            float t = (Time.time - riseStartTime) / riseTime;
            float frequency = Mathf.Lerp(0f, 0.4f, t);
            rend.material.SetFloat("_LineMorph", frequency);
            yield return null;
        }

        // Optional: Snap to 100 right before next beat (ensure it's correct)
        rend.material.SetFloat("_LineMorph", 0.4f);
    }
    
    private IEnumerator AnimateDelayed(int beatNumber)
    {
        yield return new WaitForSeconds(moveDelay);

        // Snap forward along Z axis
        StartCoroutine(LineAnimation(beatNumber));
    }

}
