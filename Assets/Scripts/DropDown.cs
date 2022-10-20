using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropDown : MonoBehaviour
{
    Dropdown.OptionData m_option1, m_option2, m_option3;
    public Text m_text;
    Dropdown m_dropdown;

    void Start()
    {
        m_dropdown = GetComponent<Dropdown>();
        m_dropdown.ClearOptions();
    }

    void Update()
    {
        
    }
}
