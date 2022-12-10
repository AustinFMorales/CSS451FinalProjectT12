using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SundialInteractable : MonoBehaviour
{
    public float m_Radius;
    public Transform m_Sphere;

    // Start is called before the first frame update
    void Start()
    {
        m_Sphere = transform.Find("Sundial Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 OriginToSphere = new Vector3(m_Sphere.localPosition.x, 0.0f, m_Sphere.localPosition.z).normalized;
        OriginToSphere *= m_Radius;
        m_Sphere.localPosition = OriginToSphere;
    }

    public float GetRotation()
    {
        int sign = 1;
        if (m_Sphere.localPosition.z < -Mathf.Epsilon)
            sign = -1;
        return sign * Mathf.Acos(Vector3.Dot(transform.right, m_Sphere.localPosition.normalized));
    }

    public void SetRotation(float radians)
    {
        float positionX = Mathf.Cos(radians) * m_Radius;
        float positionZ = Mathf.Sin(radians) * m_Radius;
        m_Sphere.localPosition = new Vector3(positionX, 0.0f, positionZ);
    }
}
