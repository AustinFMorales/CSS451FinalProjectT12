using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SmallCameraAngle : MonoBehaviour
{
    public Transform m_Target;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(m_Target);
    }
}
