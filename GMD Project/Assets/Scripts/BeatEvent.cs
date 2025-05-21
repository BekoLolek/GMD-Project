using UnityEngine;

[System.Serializable]
public class BeatEvent {
    public int beatNumber;
    public int lane;

    public int type;

    public float GetTime(float bpm)
    {
        return (60f / bpm) * beatNumber;
    }
}
