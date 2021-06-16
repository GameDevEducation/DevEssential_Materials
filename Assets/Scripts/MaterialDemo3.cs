using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialDemo3 : MonoBehaviour
{
    [SerializeField] List<Material> Materials;

    MeshRenderer LinkedMR;

    // Start is called before the first frame update
    void Start()
    {
        // retrieve the linked MeshRenderer
        LinkedMR = GetComponent<MeshRenderer>();

        // assign a random material from the list
        LinkedMR.sharedMaterial = Materials[Random.Range(0, Materials.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
