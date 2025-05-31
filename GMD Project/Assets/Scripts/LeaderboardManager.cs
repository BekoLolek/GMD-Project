using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Dropdown levelDropdown;
    public Transform leaderboardContent;
    public GameObject entryPrefabEven;
    public GameObject entryPrefabOdd;

    [Header("Data References")]
    public List<LevelDataSO> allLevels;

    private LevelDataSO currentLevel;

    
    void OnEnable()
    {
        if (ScoreSubmitter.scoreReady)
        {
            AddNewScore(
                ScoreSubmitter.playerName,
                ScoreSubmitter.score,
                ScoreSubmitter.levelPlayed
            );
            ScoreSubmitter.Clear();
        }
        PopulateDropdown();
        levelDropdown.onValueChanged.AddListener(OnLevelChanged);


        OnLevelChanged(0);
    }

    void PopulateDropdown()
    {
        levelDropdown.ClearOptions();
        var options = allLevels.Select(l => l.levelName).ToList();
        levelDropdown.AddOptions(options);
    }

    void OnLevelChanged(int selectedIndex)
    {
        if (selectedIndex < 0 || selectedIndex >= allLevels.Count)
            return;

        currentLevel = allLevels[selectedIndex];
        LeaderboardStorage.LoadLeaderboard(currentLevel.leaderboardData);
        ShowEntries(currentLevel.leaderboardData.entries);
    }

    void ShowEntries(List<LeaderboardEntry> entries)
    {
        // Clear current UI entries
        foreach (Transform child in leaderboardContent)
            Destroy(child.gameObject);

        // Sort and limit entries
        var topEntries = entries.OrderByDescending(e => e.score).Take(10);

        int i = 0;
        foreach (var entry in topEntries)
        {
            GameObject prefabToUse = (i % 2 == 0) ? entryPrefabEven : entryPrefabOdd;
            GameObject item = Instantiate(prefabToUse, leaderboardContent);
            var texts = item.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = entry.name;
            texts[1].text = entry.score.ToString();
            i++;
        }
    }

    public void AddNewScore(string name, int score, LevelDataSO levelData)
{
    var leaderboard = levelData.leaderboardData;

    var existing = leaderboard.entries
        .FirstOrDefault(e => e.name == name);

    if (existing == null || score > existing.score)
    {
        leaderboard.entries.RemoveAll(e => e.name == name);
        leaderboard.entries.Add(new LeaderboardEntry
        {
            name = name,
            score = score
        });

        leaderboard.entries = leaderboard.entries
            .OrderByDescending(e => e.score)
            .Take(10)
            .ToList();

        
        LeaderboardStorage.SaveLeaderboard(leaderboard);
    }

    
    if (currentLevel == levelData)
        ShowEntries(leaderboard.entries);
}

}
