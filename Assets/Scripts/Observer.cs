using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer:MonoBehaviour
{
    public abstract void OnNotify(string value, string u_event);
}
