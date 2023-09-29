using UnityEngine;
using TMPro;
using System.Collections;

public class DestroyOnClick : MonoBehaviour
{
    [SerializeField] private GameObject feedbackTextPrefab;
    private void Update()
    {
        // For PC (Unity Editor or standalone build)
        if (Input.GetMouseButtonDown(0))
        {
            HandleInteraction(Input.mousePosition);
        }

        // For Mobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleInteraction(Input.GetTouch(0).position);
        }
    }

    private void HandleInteraction(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                ScoreSystem.instance.AddScore(10);
                ShowFeedbackAndDestroy(hit.point);
            }
        }
    }
    private void ShowFeedbackAndDestroy(Vector3 position)
    {
        GameObject feedbackInstance = Instantiate(feedbackTextPrefab, position, Quaternion.identity, transform.parent);
        feedbackInstance.transform.position = position + Vector3.up; // Small offset upwards

        // Assuming the feedbackInstance will destroy itself after some time (like using an animation or fading out)

        Destroy(gameObject);
    }
    //private IEnumerator DelayedDestroy()
    //{
    //    yield return new WaitForSeconds(1.0f); // You can adjust this time as needed
    //    Destroy(gameObject);
    //}

    //private IEnumerator FeedbackFadeIn()
    //{
    //    feedbackText.alpha = 0;
    //    feedbackText.gameObject.SetActive(true);
    //    float duration = 0.5f; // Fade in over 0.5 seconds, adjust as needed
    //    float elapsed = 0f;
    //    while (elapsed < duration)
    //    {
    //        elapsed += Time.deltaTime;
    //        feedbackText.alpha = Mathf.Lerp(0, 1, elapsed / duration);
    //        yield return null;
    //    }
    //}

}
