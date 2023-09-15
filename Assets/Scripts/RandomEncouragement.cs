using UnityEngine;
using TMPro;

public class RandomEncouragement : MonoBehaviour
{
    public string[] encouragementMessages;
    public float displayDuration = 5.0f;  // Time in seconds the message is displayed
    public float breakDuration = 5.0f;    // Time in seconds the text is hidden

    private float nextActionTime;  // Time for next event (either show or hide text)

    private TMP_Text textComponent;
    private bool isTextDisplayed = false;  // Track if the message is currently displayed

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        HideMessage();  // Start with the message hidden
    }

    private void Update()
    {
        // Only process if the score is more than 0
        if (ScoreSystem.instance.score > 0)
        {
            if (Time.time > nextActionTime)
            {
                if (isTextDisplayed)
                {
                    HideMessage();
                    nextActionTime = Time.time + breakDuration;
                }
                else
                {
                    ShowRandomMessage();
                    nextActionTime = Time.time + displayDuration;
                }

                isTextDisplayed = !isTextDisplayed;
            }
        }
    }

    private void ShowRandomMessage()
    {
        int randomIndex = Random.Range(0, encouragementMessages.Length);
        textComponent.text = encouragementMessages[randomIndex];
        textComponent.enabled = true;  // Make sure the text component is visible
    }

    private void HideMessage()
    {
        textComponent.enabled = false;  // Hide the text component
    }
}
