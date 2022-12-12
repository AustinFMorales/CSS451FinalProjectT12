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
    public Color NightColor;
    public Color DayColor;

    // use the transform position of the attached gameobject for light position

    public GameObject NearInstance, FarInstance;

    // use this as a debugging tool and demonstration of how lighting works
    public bool ShowLightRanges = false;

    public Scr_Model m_Model;

    public float m_Radius;

    public float m_Offset;


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

        LoadLightToShader();
        SetPosition();
        SetOffset();
    }

    public void LoadLightToShader() {
        // given the parameters we set in Mat_IlluminationShader, use them to 
        // diffuse light on a given object that has our Mat_IlluminationShader applied
        Shader.SetGlobalVector("LightPosition", transform.localPosition);
        Shader.SetGlobalColor("LightColor", LightColor);
        Shader.SetGlobalFloat("LightNear", Near);
        Shader.SetGlobalFloat("LightFar", Far);
    }

    public void SetPosition()
    {
        float time = m_Model.m_Time;

        if (m_Model.m_Time < -Mathf.Epsilon)
            LightColor = DayColor;
        else
        {
            LightColor = NightColor;
            time = Mathf.PI - time;
        }

        transform.localPosition = new Vector3(Mathf.Cos(time) * m_Radius, Mathf.Sin(Mathf.Abs(time)) * m_Radius, 0);
    }

    public void SetOffset()
    {
        m_Offset = m_Model.m_Offset;
        transform.RotateAround(Vector3.zero, Vector3.right, m_Offset * 180 / Mathf.PI);
    }
}
