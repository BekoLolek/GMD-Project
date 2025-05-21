using UnityEngine;
using System.Collections;

public class FloorAlternatePattern : MonoBehaviour
{
    
    public AudioSource audioSource;

    private Renderer rend;
    private bool toggle = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
        
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
        toggle = !toggle;
        rend.material.SetFloat("_SwapValue", toggle ? 1f : 0f);
    }

    // Update is called once per frame
    
}
