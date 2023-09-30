using UnityEngine;
using UnityEngine.UI;

public class CircularScoreBar : MonoBehaviour
{
    public Image circularBar; // Drag the fill Image (circular) here in the inspector.  
    public int maxScore = 100; // This can be set to any value which represents a full circle/score.

    private void OnEnable()
    {
        ScoreSystem.OnScoreChanged += UpdateScoreBar;  // Subscribe to the OnScoreChanged event
    }

    private void OnDisable()
    {
        ScoreSystem.OnScoreChanged -= UpdateScoreBar;  // Unsubscribe from the OnScoreChanged event
    }

    public void UpdateScoreBar(int newScore)
    {
        circularBar.fillAmount = (float)newScore / maxScore;
    }


}
