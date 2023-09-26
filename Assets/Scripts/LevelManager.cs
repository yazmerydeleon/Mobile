using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public ParticleSystem levelStartParticles; // Drag your Particle System here in the Inspector

    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private GameObject endLevelPanel;  // A UI Panel to display level-end info

    [SerializeField] private TMP_Text NextLevelText;
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

    public void NextLevel()
    {        
        // Display message
        NextLevelText.gameObject.SetActive(true);
    }

}
