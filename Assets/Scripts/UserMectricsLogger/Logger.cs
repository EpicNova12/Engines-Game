using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : Observer
{
    public static Logger instance;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        Debug.Log("Logger Active");
        InputHandler.instance.AddObserver(this);
    }
    public override void OnNotify(string value, string u_event)
    {
        //Detects if user jumps
        if(u_event=="Jump")
        {
            UserMectrics.instance.IncreaseVariable("Jumps");
        }
        else if (u_event == "ExtraShot")
        {
            UserMectrics.instance.IncreaseVariable("ExtraShots");
        }
        else if (u_event == "Shoot")
        {
            UserMectrics.instance.IncreaseVariable("BulletsFired");
        }
        else if (u_event == "Swing")
        {
            UserMectrics.instance.IncreaseVariable("MeleeAttacks");
        }
    }
}
