using UnityEngine;

public class AnimatePerson : MonoBehaviour
{
    private Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = 60f / 130f;
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

        HandleAnimation(beatNumber);

    }

    void HandleAnimation(int beat)
    {
        animator.Play("Idle", 0, 0f);
    }

}
