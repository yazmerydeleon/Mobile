using UnityEngine;
using TMPro;
using System;


public class GameTimer : MonoBehaviour
{
    public static event Action OnTimerFinished;

    [SerializeField] private TextMeshProUGUI timerText;  // Reference to the TextMeshProUGUI component
    [SerializeField] private float countdownTime = 90f;  // Starting time for the countdown in seconds

    private float remainingTime;

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

            // Convert the remaining time to seconds
            int seconds = (int)(remainingTime);

            // Display the countdown timer
            timerText.text = seconds.ToString();
        }
        else
        {
            timerText.text = "0";
            if (OnTimerFinished != null)
            {
                OnTimerFinished.Invoke();
            }
        }

    }

    // Getter method to check if the countdown has finished
    public bool IsCountdownFinished()
    {
        return remainingTime <= 0;
    }
}
