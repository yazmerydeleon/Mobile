using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeartScoreBar : MonoBehaviour
{
    public Image HeartBar; // Drag the fill Image (circular) here in the inspector.  
    public int maxScore = 100; // This can be set to any value which represents a full circle/score.

  //  public Animator animator; // Drag the Animator component of your animated object here

    public DissolvingController dissolvingController;

    //private string animationTrigger = "PlayHeartMovementTrigger"; // Match this with the trigger name in your Animator Controller

   // public AudioSource backgroundMusic;
    private float originalVolume;

  //  public AudioSource audioSource; // Drag the AudioSource component here in the inspector.
  //  public AudioClip animationSound; // Drag your sound effect here in the inspector.

    //private void Awake()
    //{
    //    originalVolume = backgroundMusic.volume;
    //}

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
        HeartBar.fillAmount = (float)newScore / maxScore;

        // Check if the score bar is full
        if ((float)newScore / maxScore >= 1.0f)
        {
            // Disallow clicking on plates while animation is playing
         //   DestroyOnClick.canClickObjects = false;

            // Reduce the volume of the background music
      //      backgroundMusic.volume *= 0.5f;  // This reduces the volume to half. Adjust as needed.

            // PlayAnimation();

            StartCoroutine(ResetHeartBarAfterDissolve());
        }
    }
    private void PlayAnimation()
    {
        // Trigger the animation
       // animator.SetTrigger(animationTrigger);

    }
    //public void OnAnimationCompleted()
    //{
    //    // Disable the GameObject with the animation
    //      animator.gameObject.SetActive(false);

    //   // StartCoroutine(dissolvingController.DissolveCoRoutine());

    //    StartCoroutine(ResetHeartBarAfterDissolve());
    //}

    private IEnumerator ResetHeartBarAfterDissolve()
    {
        // Start the dissolve effect
        yield return StartCoroutine(dissolvingController.DissolveCoRoutine());        

        // Restore the volume of the background music
        //backgroundMusic.volume = originalVolume;

        // Restore the ability to click on plates
        DestroyOnClick.canClickObjects = true;

        // After dissolve is complete, reset the heart bar fill
        HeartBar.fillAmount = 0;
        maxScore = 1000;
    }

    public void PlaySound()
    {
      //  audioSource.clip = animationSound;
       // audioSource.Play();
    }
}
