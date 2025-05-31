using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class LeaderboardStorage
{
    private static string GetPath(LeaderboardDataSO leaderboard)
    {
        string dir = Path.Combine(Application.persistentDataPath, "Leaderboards");
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        return Path.Combine(dir, leaderboard.levelName + ".json");
    }

    public static void SaveLeaderboard(LeaderboardDataSO leaderboard)
    {
        string path = GetPath(leaderboard);
        string json = JsonUtility.ToJson(leaderboard, true);
        File.WriteAllText(path, json);
    }

    public static void LoadLeaderboard(LeaderboardDataSO leaderboard)
    {
        string path = GetPath(leaderboard);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, leaderboard);
        }
    }

    public static void ClearLeaderboard(LeaderboardDataSO leaderboard)
    {
        leaderboard.entries.Clear();
        SaveLeaderboard(leaderboard);
    }
}

