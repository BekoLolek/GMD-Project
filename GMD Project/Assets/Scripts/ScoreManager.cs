using System;
using System.Threading;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;
    public int combo = 0;
    public int multiplier = 1;

    public int scoreTimeMultiplier = 50;

    public int scorePerHit = 100;
    public int scorePenalty = 50;
    public int comboThreshold = 10;

    public TMP_Text scoreText;
    public TMP_Text multiplierText;

    private float scoreAccumulator = 0f;

    public GameObject scoreChangeTextPrefab;
    public Transform scoreTextAnchor;

    public bool started = false;

    public static bool isStarted { get; set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (started)
        {
            started = true;
            scoreAccumulator += scoreTimeMultiplier * Time.deltaTime;

            if (scoreAccumulator >= 1f)
            {
                int increment = Mathf.FloorToInt(scoreAccumulator);
                score += increment;
                scoreAccumulator -= increment;
                UpdateUI();
            }
        }


    }

    public void RegisterPerfectHit()
    {
        combo++;
        if (combo % comboThreshold == 0)
        {
            multiplier++;
        }

        score += scorePerHit * multiplier;
        ShowScoreChange(scorePerHit * multiplier);
        UpdateUI();
    }

    public void RegisterMiss()
    {
        score = Mathf.Max(0, score - scorePenalty * multiplier);
        ShowScoreChange(-scorePenalty * multiplier);

        combo = 0;
        multiplier = 1;

        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";

        if (multiplierText != null)
            multiplierText.text = $"x{multiplier}";
    }

    public void ShowScoreChange(int amount)
    {
        GameObject go = Instantiate(scoreChangeTextPrefab, scoreTextAnchor);
        go.GetComponent<ScoreChangePopup>().Setup(amount);
    }

    public void startScoring()
    {
        started = true;
    }
}
