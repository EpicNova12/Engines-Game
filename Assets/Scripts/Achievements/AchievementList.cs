using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementList : MonoBehaviour
{
    public static AchivementList instance;

    //Achievements
    Achivement Test = new Achivement();
    Achivement TestNum = new Achivement();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //Activate Achievements
    private void Start()
    {
        //Test
        Test.u_name = "Test";

        //Test Num
        TestNum.u_name = "Test Num";
        TestNum.goal = 5.0f;
    }
}
