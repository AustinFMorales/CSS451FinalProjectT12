using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PointLight : MonoBehaviour
{
    // Austin Ferdinand Morales
    // the pointlight definition is derived from Week 9, Example 3

    // responsible of controlling the near sphere's scale
    public float Near = 5.0f; 
    // responsible of controlling the far sphere's scale
    public float Far = 10.0f;
    
    // control the light color emitted from the Scr_PointLight
    public Color LightColor = Color.white;
    
    // use the transform position of the attached gameobject for light position
    
    public GameObject NearInstance, FarInstance;

    // use this as a debugging tool and demonstration of how lighting works
    public bool ShowLightRanges = false;
    
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = LightColor;
        NearInstance.SetActive(ShowLightRanges);
        FarInstance.SetActive(ShowLightRanges);

        // the code here is responsible for keeping the near and far positions to be updated
        Color c = LightColor;
        c.a = 0.2f;
        NearInstance.transform.localPosition = transform.localPosition;
        NearInstance.transform.localScale = new Vector3(2 * Near, 2 * Near, 2 * Near);
        NearInstance.GetComponent<Renderer>().material.color = c;

        c.a = 0.1f;
        FarInstance.transform.localPosition = transform.localPosition;
        FarInstance.transform.localScale = new Vector3(2 * Far, 2 * Far, 2 * Far);
        FarInstance.GetComponent<Renderer>().material.color = c;
    }

    public void LoadLightToShader() {
        // given the parameters we set in Mat_IlluminationShader, use them to 
        // diffuse light on a given object that has our Mat_IlluminationShader applied
        Shader.SetGlobalVector("LightPosition", transform.localPosition);
        Shader.SetGlobalColor("LightColor", LightColor);
        Shader.SetGlobalFloat("LightNear", Near);
        Shader.SetGlobalFloat("LightFar", Far);
    }
}
