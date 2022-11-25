using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public static MenuControl instance;

    public Canvas UI;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    
    public void OpenMenu()
    {
        if(UI.enabled==false)
        {
            UI.enabled = true;
        }
        else if(UI.enabled==true)
        {
            UI.enabled = false;
        }
    }
}
