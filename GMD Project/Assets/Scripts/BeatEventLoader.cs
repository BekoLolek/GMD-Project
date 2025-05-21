using System.Collections.Generic;
using UnityEngine;

public class BeatEventLoader : MonoBehaviour
{
    
    public TextAsset csvFile; 
    public BeatmapSO beatmapSO;

    void Start()
    {
        List<BeatEvent> loadedEvents = new List<BeatEvent>();

        string[] lines = csvFile.text.Split('\n');

        for (int i = 1; i < lines.Length; i++) 
        {
            string line = lines[i].Trim();

            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(',');

            if (parts.Length >= 3 &&
                int.TryParse(parts[0], out int beat) &&
                int.TryParse(parts[1], out int lane) &&
                int.TryParse(parts[2], out int type))
            {
                loadedEvents.Add(new BeatEvent
                {
                    beatNumber = beat,
                    lane = lane,
                    type = type
                });
            }
        }

        beatmapSO.SetEvents(loadedEvents);
        Debug.Log($"Loaded {loadedEvents.Count} beat events.");
    }
}
