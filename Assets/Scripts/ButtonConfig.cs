using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonConfig : MonoBehaviour
{
    InputHandler m_input;
    public Button m_button;
    public Text m_text;
    public Command m_Command;
    int currentConfig;

    void Awake()
    {
        m_button = GetComponent<Button>();
        m_text = GetComponent<Text>();
        m_input = GetComponent<InputHandler>();

        m_button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (currentConfig==1)
        {
            UpdateText("Config 1");
        }
        if (currentConfig == 2)
        {
            UpdateText("Config 2");
        }
    }
    
    private void UpdateText(string newText)
    {
        m_text.text = newText;
    }

    private void SwapKeys(int config)
    {
        if (config==1)
        {
           
        }
    }

}
