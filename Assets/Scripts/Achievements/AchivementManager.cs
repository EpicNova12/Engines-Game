using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementManager : Observer
{
    public Subject u_subject;
    private void Awake()
    {
        u_subject= GetComponent<Subject>();
        u_subject.AddObserver(this);
    }

    public override void OnNotify(string value,string u_event)
    {
        //u_event is how the type of event is dictated

        //Alpha is the code for Mectrics Logging
        if(u_event=="Alpha")
        {
            Debug.Log("You got the " + value + "Achivement!");
        }
    }

    private void GetAchievement(Achivement u_achivement)
    {
        u_achivement.ChangeStatus();
    }
}
