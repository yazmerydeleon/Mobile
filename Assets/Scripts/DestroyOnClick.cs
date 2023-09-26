using UnityEngine;
public class DestroyOnClick : MonoBehaviour
{
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
                Destroy(gameObject);
            }
        }
    }
}
