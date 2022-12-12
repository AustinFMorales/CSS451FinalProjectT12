using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Controller : MonoBehaviour
{
    public SceneNode RootNode;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(RootNode != null);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Matrix4x4 m = Matrix4x4.identity;
        RootNode.CompositeXform(ref m);
    }

    public SceneNode GetRootNode() { return RootNode; }
    
}
