using UnityEngine;
using TMPro;

public class CubeClickHandler : MonoBehaviour
{
    public TMP_Text messageText; 

    private void Update()
    {
        // For PC and Unity Editor
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    DisplayMessage("Cube was clicked!");
                }
            }
        }

        // For Mobile (This is optional if you only want it to work on PC)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    DisplayMessage("Cube was touched!");
                }
            }
        }
    }

    private void DisplayMessage(string message)
    {
        messageText.text = message;
    }
}
