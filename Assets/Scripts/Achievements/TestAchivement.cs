using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAchivement:Subject
{
    void Update()
    {
        if(Input.GetKey(KeyCode.M))
        {
            Notify("Test", "Alpha");
        }
    }
}
