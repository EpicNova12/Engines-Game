using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonConfig : MonoBehaviour
{
    public Button m_button;
    public TMP_Text m_text;
    int currentConfig=1;

    void Awake()
    {
        m_button = GetComponent<Button>();
        m_text = GetComponent<TMP_Text>();

        //m_button.onClick.AddListener(ChangeConfig);
    }

    public void Update()
    {
        //I want to have this done in GUI but due to time I have to simplify it to show functionality
        //Also Unity GUI is giving me the run around
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentConfig = 1;
            SwapKeys(currentConfig);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentConfig = 2;
            SwapKeys(currentConfig);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentConfig = 3;
            SwapKeys(currentConfig);
        }
    }
    /*public void ChangeConfig()
    {
        if (currentConfig==1)
        {
            //UpdateText("Config 1");
            SwapKeys(currentConfig);
        }
        else if (currentConfig == 2)
        {
            //UpdateText("Config 2");
            SwapKeys(currentConfig);
        }
    }*/
    
    private void UpdateText(string newText)
    {
        m_text.text = newText;
    }

    private void SwapKeys(int config)
    {
        if(config==1)
        {
            InputHandler.instance.SetDefault();
        }
        else if(config==2)
        {
            InputHandler.instance.SwapKeys("Shoot", KeyCode.Mouse1);
            InputHandler.instance.SwapKeys("Melee", KeyCode.Mouse0);
            InputHandler.instance.SwapKeys("Reload",KeyCode.Mouse3);
        }
        else if (config == 3)
        {
            InputHandler.instance.SwapKeys("Shoot", KeyCode.Mouse1);
            InputHandler.instance.SwapKeys("Melee", KeyCode.Mouse0);
            InputHandler.instance.SwapKeys("Reload", KeyCode.Mouse3);
            InputHandler.instance.SwapKeys("Jump",KeyCode.RightControl);
        }
    }

}
