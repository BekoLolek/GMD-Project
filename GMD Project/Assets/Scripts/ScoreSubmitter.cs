public static class ScoreSubmitter
{
    public static string playerName;
    public static int score;
    public static LevelDataSO levelPlayed;
    public static bool scoreReady = false;

    public static void SubmitScore(string name, int scoreValue, LevelDataSO level)
    {
        playerName = name;
        score = scoreValue;
        levelPlayed = level;
        scoreReady = true;
    }

    public static void Clear()
    {
        playerName = "";
        score = 0;
        levelPlayed = null;
        scoreReady = false;
    }
}
