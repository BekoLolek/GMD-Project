using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LeaderboardData", menuName = "Game/Leaderboard Data")]
public class LeaderboardDataSO : ScriptableObject
{
    public string levelName; 

    public List<LeaderboardEntry> entries = new();
}

[System.Serializable]
public class LeaderboardEntry
{
    public string name;
    public int score;
}
