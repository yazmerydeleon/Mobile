using UnityEngine;

public class ObjectsDestructionZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Destroy the object
        Destroy(other.gameObject);

    }

}
