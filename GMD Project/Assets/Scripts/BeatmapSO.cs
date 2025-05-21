using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Beatmap/Create New Beatmap")]
public class BeatmapSO : ScriptableObject
{
    [SerializeField]
    public List<BeatEvent> events = new List<BeatEvent>();

    public List<BeatEvent> Events => events;

    public void SetEvents(List<BeatEvent> newEvents)
    {
        events = newEvents;
    }
}
