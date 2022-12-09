using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Model : MonoBehaviour
{
    public GameObject[] m_Prefabs;
    public Transform m_LeftController;
    
    public void CreatePrefab(int selection)
    {
        Instantiate(m_Prefabs[selection], m_LeftController.position, m_LeftController.rotation);
    }

    public void CreatePrefab(GameObject prefab)
    {
        Instantiate(prefab, m_LeftController.position, m_LeftController.rotation);
    }
}
