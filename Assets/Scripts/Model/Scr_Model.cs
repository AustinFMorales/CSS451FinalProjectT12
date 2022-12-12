using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Model : MonoBehaviour
{
    public GameObject[] m_Prefabs;
    public Transform m_LeftController;

    protected float m_ScaleMultiplier;

    public Scr_SundialInteractable m_SundialInteractable;
    public Scr_NeedleInteractable m_NeedleInteractable;

    public float m_Time;
    public float m_Offset;

    public Transform m_SundialDisk; // the sundial disk transform
    public Transform m_SundialGnomon; // the sundial needle transform

    public bool m_PassageOfTime; // should the days goes by
    public float m_TimeSpeed; // how fast should the days go by

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

    public void updateTime()
    {
        m_Time = m_SundialInteractable.GetRotation();
    }

    void Update()
    {
        if (m_PassageOfTime)
        {
            m_SundialInteractable.SetRotation(m_SundialInteractable.GetRotation() - m_TimeSpeed);
            updateTime();

            m_SundialDisk.Rotate(new Vector3(0.0f, m_TimeSpeed * 360, 0.0f));
        }
    }

    public void SetPassageOfTime(bool value)
    {
        m_PassageOfTime = value;
    }

    public void updateOffset()
    {
        m_Offset = m_NeedleInteractable.m_Theta;
    }
}
