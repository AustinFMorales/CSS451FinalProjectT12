using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Sung-Joon Im
Widget forward must be pointining inwards towards the controller
This script is purely to show and hide a widget
*/
public class Scr_WidgetVisibility : MonoBehaviour
{
    public Camera m_MainCamera;
    void Start()
    {
        m_MainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Dot(-transform.forward, (m_MainCamera.transform.position - transform.position).normalized) > 0.7)
        {
            if (GetComponent<MeshRenderer>() != null)
                GetComponent<MeshRenderer>().enabled = true;
            else if (GetComponent<Canvas>() != null)
                GetComponent<Canvas>().enabled = true;
        }
        else
        {
            if (GetComponent<MeshRenderer>() != null)
                GetComponent<MeshRenderer>().enabled = false;
            else if (GetComponent<Canvas>() != null)
                GetComponent<Canvas>().enabled = false;
        }
    }
}
