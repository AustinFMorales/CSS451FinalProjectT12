using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Delete : MonoBehaviour
{
    public void DeleteSelf()
    {
        GameObject.Destroy(gameObject);
    }
}
