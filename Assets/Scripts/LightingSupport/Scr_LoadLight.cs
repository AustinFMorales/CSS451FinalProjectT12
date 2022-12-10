using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_LoadLight : MonoBehaviour
{
    // Austin Ferdinand Morales
    // example is taken from Professor Sung - Week 9 Example 3
    
    public Scr_PointLight LightSource;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(LightSource != null);
    }

    // Update is called once per frame
    void Update()
    {
        LightSource.LoadLightToShader();
    }
}
