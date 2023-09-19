using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnClick : MonoBehaviour
{
    [SerializeField] private GameObject feedbackTextPrefab;  // A prefab that contains the feedback text as a UI element
    [SerializeField] private Vector3 textOffset; // Adjust this to position the text above/beside your game object

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

                ShowFeedbackText();
                Destroy(gameObject);
            }
        }
    }

    private void ShowFeedbackText()
    {
        GameObject feedbackText = Instantiate(feedbackTextPrefab, transform.position + textOffset, Quaternion.identity);
        Destroy(feedbackText, 1f); // Destroy the feedback text after 2 seconds
    }
}
