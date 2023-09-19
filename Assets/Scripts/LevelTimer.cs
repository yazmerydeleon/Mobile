using UnityEngine;
using TMPro;
using System;

public class LevelTimer : MonoBehaviour
{
    public static event Action OnTimerFinished;

    [SerializeField] private TextMeshProUGUI timerText;  // Reference to the TextMeshProUGUI component
    [SerializeField] private float countdownTime = 90f;  // Starting time for the countdown in seconds

    private float remainingTime;
    private bool hasTimerFinished = false;  // This flag ensures the OnTimerFinished event is triggered only once

    // Game active state flag
    public static bool isGameActive = true;

    private void Start()
    {
        remainingTime = countdownTime; // Initialize the countdown with the specified starting time
    }

    private void Update()
    {
        // Reduce the remaining time
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            int minutes = (int)(remainingTime / 60);
            int seconds = (int)(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
        else if (!hasTimerFinished)  // Check the flag to prevent multiple invocations
        {
            timerText.text = "0";
            OnTimerFinished?.Invoke();  // The '?' checks if there are any subscribers before invoking
            hasTimerFinished = true;  // Set the flag
            isGameActive = false;     // Set the game state to inactive once the timer finishes
        }
    }

    // Getter method to check if the countdown has finished
    public bool IsCountdownFinished()
    {
        return remainingTime <= 0;
    }
}
