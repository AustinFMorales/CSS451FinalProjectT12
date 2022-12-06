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
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<Canvas>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Canvas>().enabled = false;
        }
    }
}
