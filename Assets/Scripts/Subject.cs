using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject :MonoBehaviour
{
    List<Observer> observers = new List<Observer>();

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void Notify(string value, string u_event)
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].OnNotify(value, u_event);
        }
    }
}
