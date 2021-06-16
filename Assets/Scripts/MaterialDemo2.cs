using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialDemo2 : MonoBehaviour
{
    [SerializeField] float FadePeriod = 5f;

    [Header("Emission Settings")]
    [SerializeField] bool HasEmission = false;
    [SerializeField] [ColorUsage(false, true)] Color EmissionColour = Color.black;

    MeshRenderer LinkedMR;

    MaterialPropertyBlock propertyBlock;

    // Start is called before the first frame update
    void Start()
    {
        // retrieve the linked MeshRenderer
        LinkedMR = GetComponent<MeshRenderer>();

        // create the property block
        propertyBlock = new MaterialPropertyBlock();

        // set a random colour
        propertyBlock.SetColor("_Color", Random.ColorHSV());

        // configure the emission colour if enabled
        if (HasEmission)
        {
            // propertyblocks don't support enabling a specific keyword - this WILL create a new instance
            LinkedMR.material.EnableKeyword("_EMISSION");
            propertyBlock.SetColor("_EmissionColor", EmissionColour);
        }

        // apply the changes
        LinkedMR.SetPropertyBlock(propertyBlock);        
    }

    // Update is called once per frame
    void Update()
    {
        // calculate our alpha - use pingpong so it cycles
        float desiredAlpha = 1f - (Mathf.PingPong(Time.time, FadePeriod) / FadePeriod);

        // Update the alpha/transparency for the material
        Color currentColour = propertyBlock.GetColor("_Color");
        currentColour.a = desiredAlpha;
        propertyBlock.SetColor("_Color", currentColour);

        // apply the changes
        LinkedMR.SetPropertyBlock(propertyBlock);                 
    }
}
