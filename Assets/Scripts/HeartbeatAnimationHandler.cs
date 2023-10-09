using UnityEngine;

public class HeartbeatAnimationHandler : MonoBehaviour
{
    public HeartScoreBar heartScoreBar; // Drag the Score Manager GameObject (which has the HeartScoreBar script) here in the Inspector

    public void OnAnimationCompleted()
    {
        heartScoreBar.OnAnimationCompleted(); // Or whatever method you want to call in HeartScoreBar
    }

    //public void OnAnimationStarted()
    //{
    //    heartScoreBar.PlaySound(); // Or whatever method you want to call in HeartScoreBar
    //}
}
