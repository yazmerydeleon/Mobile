using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeartScoreBar : MonoBehaviour
{
    public Image HeartBar; // Drag the fill Image (circular) here in the inspector.  
    public int maxScore = 200; // This can be set to any value which represents a full circle/score.

    public ParticleSystem heartFullParticles;

    public GameObject prefabToEnable;

    private bool resettingHeartBar = false; // New variable to check if we should reset the bar

    public DissolvingController dissolvingController;

    private float originalVolume;


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
            EnablePrefab();
            StartHeartFullParticles();

            dissolvingController.BeginDissolve();

            resettingHeartBar = true;

            // After dissolve is complete, reset the heart bar fill
            HeartBar.fillAmount = 0;
            maxScore = 2000;
        }
    }

    private void EnablePrefab()
    {
        prefabToEnable.SetActive(true);
    }
    private void StartHeartFullParticles()
    {
        heartFullParticles.Play();
        StartCoroutine(StopParticlesAfterTime(10f));
    }

    private IEnumerator StopParticlesAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        heartFullParticles.Stop();
    }

}
