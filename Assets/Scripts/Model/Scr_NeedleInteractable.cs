using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_NeedleInteractable : MonoBehaviour
{
    public float m_ThetaLimit;
    public float m_Theta;

    public float m_Radius;

    public SceneNode m_Parent;

    public Transform m_Sphere;
    public Transform m_Gnomon;

    bool m_Started = false;

    void Update()
    {
        if (!m_Started)
        {
            SelectExited();
            m_Started = true;
        }
    }

    public void SelectExited()
    {
        transform.localPosition = m_Parent.mCombinedParentXform.GetColumn(3);

        Vector3 pointToSphere = new Vector3(0.0f, m_Sphere.localPosition.y, m_Sphere.localPosition.z).normalized;
        float theta = Mathf.Acos(Vector3.Dot(Vector3.up, pointToSphere));

        int sign = 1;
        if (m_Sphere.localPosition.z < -Mathf.Epsilon)
            sign = -1;

        if (theta > m_ThetaLimit)
        {
            theta = m_ThetaLimit;
        }

        m_Theta = theta * sign;

        Vector3 position = new Vector3(0.0f, Mathf.Cos(m_Theta) * m_Radius, Mathf.Sin(m_Theta) * m_Radius);

        m_Sphere.localPosition = position;
    }

    public void updateNeedle()
    {
        m_Gnomon.localRotation = Quaternion.identity;
        m_Gnomon.Rotate(new Vector3(m_Theta * 180 / Mathf.PI, 0.0f, 0.0f));
    }
}
