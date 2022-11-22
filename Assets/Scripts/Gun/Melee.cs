using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public static Melee instance;

    //Weapon
    public GameObject meleeWeapon;
    private BoxCollider meleeHitbox;

    //Variables
    private bool swing = false;
    private int cycle = 0;
    public int attackSpeed;    //How many frames the hitbox will last, so the lower it is the faster the attack
    public float damageReg;
    public float damageBuff;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        //Set the melee hitbox to our weapons hitbox
        meleeHitbox = meleeWeapon.GetComponent<BoxCollider>();
        meleeHitbox.enabled = false;
    }

    public void Strike()
    {
        //Activate Collider for Swing
        meleeHitbox.enabled = true;
        swing = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Start the hitbox timer
        if(swing==true)
        {
            //Keeps track of frames
            cycle = cycle + 1;
        }
        if(cycle>=attackSpeed)
        {
            swing = false;
            cycle = 0;
            meleeHitbox.enabled = false;
        }
    }
}
