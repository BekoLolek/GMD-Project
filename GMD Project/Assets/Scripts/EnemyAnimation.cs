using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = 300f / 130f;
    }

    void OnEnable()
    {
        SetInitialPose();
        BeatManager.OnBeat += HandleBeat;
    }

    void OnDisable()
    {
        BeatManager.OnBeat -= HandleBeat;
    }

    void SetInitialPose()
    {
        int beat = BeatManager.CurrentBeatNumber;
        HandleAnimation(beat);

    }


    void HandleBeat(int beatNumber)
    {

        HandleAnimation(beatNumber);

    }

    void HandleAnimation(int beat)
    {
        if (beat % 2 == 0)
        {
            animator.Play("Idle", 0, 0f);
        }
        else
        {
            animator.Play("Idle", 0, 0.5f);
        }
    }


}
