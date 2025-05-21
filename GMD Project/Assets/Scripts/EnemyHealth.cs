using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hitsRequired = 1;
    private int currentHits = 0;
    private float lastHitBeatTime = -1f;

    public bool RegisterHit(float currentBeatTime, float beatInterval, float hitWindow)
    {
        if (currentHits > 0)
        {
            float delta = Mathf.Abs(currentBeatTime - lastHitBeatTime);
            if (delta > hitWindow) return false;
        }

        currentHits++;
        lastHitBeatTime = currentBeatTime;
        return currentHits >= hitsRequired;
    }
}
