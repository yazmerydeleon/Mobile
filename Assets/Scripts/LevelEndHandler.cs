using UnityEngine;
using TMPro;

public class LevelEndHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private GameObject endLevelPanel;  // A UI Panel to display level-end info
    private int currentScore;

    private void OnEnable()
    {
        GameTimer.OnTimerFinished += EndLevel;
    }

    private void OnDisable()
    {
        GameTimer.OnTimerFinished -= EndLevel;
    }

    public void UpdateScore(int score)
    {
        currentScore = score;
    }

    private void EndLevel()
    {
        // Show the end-level UI panel
        endLevelPanel.SetActive(true);

        // Display the player's score
        scoreDisplay.text = "Score: " + currentScore;
    }
}
