using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance; // Singleton reference
    public int score = 0; // Current score
    public TMP_Text scoreText;
    public TMP_Text bestScoreText;

    public delegate void ScoreChangedDelegate(int newScore);
    public static event ScoreChangedDelegate OnScoreChanged;

    public HeartScoreBar circularScoreBar;  // Drag and drop the HeartScoreBar component here in the inspector.
    public int thresholdToShowCircularBar = 50; // Define your threshold value here, for instance, I'm using 50 as a placeholder.

    public int BestScore
    {
        get { return PlayerPrefs.GetInt("BestScore", 0); }
        set { PlayerPrefs.SetInt("BestScore", value); }
    }

    private void Awake()
    {
        // Singleton pattern ensures only one ScoreSystem exists in the scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Your Score: " + score;
        Debug.Log("Score: " + score);

        if (score > BestScore)
        {
            BestScore = score;
            bestScoreText.text = "Best Score: " + BestScore;
        }

        if (score >= thresholdToShowCircularBar)
        {
            circularScoreBar.HeartBar.gameObject.SetActive(true);
        }

        OnScoreChanged?.Invoke(score);  // <-- Raise the event here

    }
}
