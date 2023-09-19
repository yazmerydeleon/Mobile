using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private GameObject endLevelPanel;  // A UI Panel to display level-end info

    private void OnEnable()
    {
        LevelTimer.OnTimerFinished += EndLevel;
    }

    private void OnDisable()
    {
        LevelTimer.OnTimerFinished -= EndLevel;
    }

    private void EndLevel()
    {
        // Get the current score from the ScoreSystem
        int finalScore = ScoreSystem.instance.score;

        // Show the end-level UI panel
        endLevelPanel.SetActive(true);

        // Display the player's score
        scoreDisplay.text = "Score: " + finalScore;
    }

    public void ReplayLevel()
    {
        // Reset the game state
        LevelTimer.isGameActive = true;
        LevelTimer.OnTimerFinished -= EndLevel; // To ensure we don't have multiple subscriptions
                                               // Reload the current scene (i.e., replay the level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
