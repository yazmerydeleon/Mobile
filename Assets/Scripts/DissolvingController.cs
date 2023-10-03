using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolvingController : MonoBehaviour
{
    public List<MeshRenderer> skinnedMeshes;  // List of MeshRenderers

    private List<Material[]> skinnedMaterialsList = new List<Material[]>();

    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;

    private void Start()
    {
        foreach (var mesh in skinnedMeshes)
        {
            if (mesh != null)
            {
                skinnedMaterialsList.Add(mesh.materials);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DissolveCoRoutine());
        }
    }

    public IEnumerator DissolveCoRoutine()
    {
        float counter = 0;

        bool allDissolved = false;
        while (!allDissolved)
        {
            counter += dissolveRate;

            allDissolved = true;
            foreach (var materials in skinnedMaterialsList)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i].SetFloat("_DissolveAmount", counter);

                    if (materials[i].GetFloat("_DissolveAmount") < 1)
                    {
                        allDissolved = false;
                    }
                }
            }

            yield return new WaitForSeconds(refreshRate);
        }
    }
}
