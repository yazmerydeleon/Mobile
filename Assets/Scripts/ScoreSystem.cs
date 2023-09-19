using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance; // Singleton reference

    public int score = 0; // Current score

    public TMP_Text scoreText;

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
        scoreText.text = score + " Ganaste!!!";
    }
}
