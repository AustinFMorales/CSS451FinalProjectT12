using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Model : MonoBehaviour
{
    public GameObject[] m_Prefabs;
    public Transform m_LeftController;

    protected float m_ScaleMultiplier;

    void Start()
    {
        m_ScaleMultiplier = 1.0f;
    }

    public void CreatePrefab(int selection)
    {
        GameObject temp = Instantiate(m_Prefabs[selection], m_LeftController.position, m_LeftController.rotation);
        temp.transform.localScale *= m_ScaleMultiplier;
    }

    public void CreatePrefab(GameObject prefab)
    {
        GameObject temp = Instantiate(prefab, m_LeftController.position, m_LeftController.rotation);
        temp.transform.localScale *= m_ScaleMultiplier;
    }

    public void updateScaleMultipliaer(float value)
    {
        m_ScaleMultiplier = value;
    }
}
