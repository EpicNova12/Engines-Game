using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achivement : MonoBehaviour
{
    public string u_name;
    public float goal;
    private float tracking;
   // private bool status;

    public void UpdateTracking(float value)
    {
        tracking = tracking + value;
    }
    public void ChangeStatus()
    {
        //status = true;
    }
}