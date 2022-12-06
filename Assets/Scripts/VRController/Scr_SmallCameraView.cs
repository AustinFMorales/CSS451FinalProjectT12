using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SmallCameraView : MonoBehaviour
{
    public Camera MainCamera;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Dot(-transform.forward, (MainCamera.transform.position - transform.position).normalized) > 0.7)
            GetComponent<MeshRenderer>().enabled = true;
        else
            GetComponent<MeshRenderer>().enabled = false;
    }
}
