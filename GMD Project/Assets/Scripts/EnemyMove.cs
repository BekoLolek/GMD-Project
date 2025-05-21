using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float moveDistance = 2f;
    public float moveDelay = 0.2f;


    void Start()
    {
        
        transform.Rotate(0, 180, 0);

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
        StartCoroutine(MoveDelayed());
    }

    private IEnumerator MoveDelayed()
    {
        yield return new WaitForSeconds(moveDelay);

        // Snap forward along Z axis
        transform.position += Vector3.back * moveDistance; 
    }



}
