using UnityEngine;

public class DangerZoneFeedback : MonoBehaviour
{
    private Renderer rend;
    [Range(0, 1)] public float redIncrement = 0.1f;  // Amount by which the red increases each time
    private Color initialColor;
    private float currentRedValue;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        initialColor = rend.material.color;
        currentRedValue = initialColor.r;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy the object
        Destroy(other.gameObject);

        // Provide negative feedback
        IncreaseDangerFeedback();
    }

    void IncreaseDangerFeedback()
    {
        currentRedValue = Mathf.Clamp(currentRedValue + redIncrement, 0, 1); // Ensure it doesn't exceed 1
        Color dangerColor = new Color(currentRedValue, initialColor.g, initialColor.b);
        rend.material.color = dangerColor;
    }
}
