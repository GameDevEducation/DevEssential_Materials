using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialDemo1 : MonoBehaviour
{
    [SerializeField] float FadePeriod = 5f;

    [Header("Emission Settings")]
    [SerializeField] bool HasEmission = false;
    [SerializeField] [ColorUsage(false, true)] Color EmissionColour = Color.black;

    MeshRenderer LinkedMR;

    // Start is called before the first frame update
    void Start()
    {
        // retrieve the linked MeshRenderer
        LinkedMR = GetComponent<MeshRenderer>();

        // randomise the colour - just changes us
        LinkedMR.material.color = Random.ColorHSV();

        // randomise the colour - change the SHARED version (will effect others - and the asset)
        //LinkedMR.sharedMaterial.color = Random.ColorHSV();

        // configure the emission colour if enabled
        if (HasEmission)
        {
            LinkedMR.material.EnableKeyword("_EMISSION");
            LinkedMR.material.SetColor("_EmissionColor", EmissionColour);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // calculate our alpha - use pingpong so it cycles
        float desiredAlpha = 1f - (Mathf.PingPong(Time.time, FadePeriod) / FadePeriod);

        // Update the alpha/transparency for the material
        Color currentColour = LinkedMR.material.color;
        currentColour.a = desiredAlpha;
        LinkedMR.material.color = currentColour;
    }
}
