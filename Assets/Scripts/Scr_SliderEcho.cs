using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scr_SliderEcho : MonoBehaviour
{
    public TMP_Text m_Text;
    public float m_MinValue;
    public float m_MaxValue;
    public float m_InitialValue;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().minValue = m_MinValue;
        GetComponent<Slider>().maxValue = m_MaxValue;
        GetComponent<Slider>().value = m_InitialValue;
        updateEcho(m_InitialValue);
    }

    public void updateEcho(float value)
    {
        m_Text.text = string.Format("Scale Multiplier: {0}", value);
    }
}
