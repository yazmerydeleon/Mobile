using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class FunFactGenerator : MonoBehaviour
{
    public TMP_Text funFactText; // Drag your TextMeshPro UI component here in the inspector.
    public List<string> funFacts = new List<string>();

    public void ShowRandomFunFact()
    {
        Debug.Log("FunFact");
        int randomIndex = Random.Range(0, funFacts.Count);
        funFactText.text = funFacts[randomIndex];
    }
}
