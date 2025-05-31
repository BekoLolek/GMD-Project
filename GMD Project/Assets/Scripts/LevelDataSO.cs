using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Levels/Level Data")]
public class LevelDataSO : ScriptableObject
{
    public string levelName;
    public Sprite levelPreview;

    public GameObject audioManagerPrefab;

    public int bpm;

    public BeatmapSO beatmap;
    public LeaderboardDataSO leaderboardData;

}
