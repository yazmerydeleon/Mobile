using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance; // Singleton reference
    public int score = 0; // Current score
    public TMP_Text scoreText;

    public delegate void ScoreChangedDelegate(int newScore);
    public static event ScoreChangedDelegate OnScoreChanged;

    public HeartScoreBar circularScoreBar;  // Drag and drop the HeartScoreBar component here in the inspector.
    public int thresholdToShowCircularBar = 50; // Define your threshold value here, for instance, I'm using 50 as a placeholder.

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
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);

        if (score >= thresholdToShowCircularBar)
        {
            circularScoreBar.HeartBar.gameObject.SetActive(true);
        }

        OnScoreChanged?.Invoke(score);  // <-- Raise the event here
    }
}
