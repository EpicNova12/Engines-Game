using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMectrics :MonoBehaviour
{
    //Since these are the players stats there only needs to be a single instance of it
    public static UserMectrics instance;

    //Tracked Variables
    int jumps;  //Tracks how many times the player jumps
    int extraShots; //Checks how many times the player attempts to fire without ammo

    //Check balance between melee and shooting
    int bulletsFired;   //Checks how many time the player shoots
    int meleeAttacks;   //Checks how many time the player swings

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        Debug.Log("Stat Tracker Active");
    }

    public void IncreaseVariable(string var)
    {
        if (var=="Jumps")
        {
            jumps = jumps + 1;
            //Debug.Log(jumps);
        }
        else if(var=="ExtraShots")
        {
            extraShots = extraShots + 1;
            //Debug.Log(extraShots);
        }
        else if (var == "BulletsFired")
        {
            bulletsFired = bulletsFired + 1;
            //Debug.Log(bulletsFired);
        }
        else if (var == "MeleeAttacks")
        {
            meleeAttacks = meleeAttacks + 1;
            //Debug.Log(meleeAttacks);
        }
    }
}
