using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementManager : Observer
{
    Subject u_subject;
    private void Awake()
    {
        u_subject.AddObserver(this);
    }

    public override void OnNotify(string value,string u_event)
    {
        //u_event is how the type of event is dictated

        //Alpha is the code for Achivements
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
