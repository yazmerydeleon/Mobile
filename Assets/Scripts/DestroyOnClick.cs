using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class DestroyOnClick : MonoBehaviour
{
    [SerializeField] private GameObject feedbackTextPrefab;

    public static bool canClickObjects = true;
    private void Update()
    {
        // For PC (Unity Editor or standalone build)
        if (Input.GetMouseButtonDown(0))
        {
            HandleInteraction(Input.mousePosition);
            Debug.Log("GetMouseButtonDown");
        }

        // For Mobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleInteraction(Input.GetTouch(0).position);
        }
    }

    private void HandleInteraction(Vector2 position)
    {
        if (!canClickObjects) return; // This prevents interactions if clicking is disabled.

        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                ScoreSystem.instance.AddScore(10);
                ShowFeedbackAndDestroy(hit.point);
                Debug.Log("HandleInteraction");
            }
        }
    }
    private void ShowFeedbackAndDestroy(Vector3 worldPosition)
    {
        // Instantiate the feedback text at the game object's position
        GameObject feedbackInstance = Instantiate(feedbackTextPrefab, worldPosition, Quaternion.identity);

        // If the feedback text is too large or small in the world, adjust its scale here
        feedbackInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // You can adjust the scale as needed

        // Optionally, you can add logic to destroy the feedbackInstance after some time
        Destroy(feedbackInstance, 2.0f);  // for example, it'll destroy after 2 seconds

        Destroy(gameObject);
    }

}
