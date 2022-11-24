using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public static Melee instance;

    //Weapon
    public Transform weaponLoc;
    public GameObject meleeWeaponHB;
    private BoxCollider meleeHitbox;
    //So Unity makes no sense and collisions only work with rigidbodies, triggers also dont work, I guess colliders are pointless, wasted a whole day on this thanks unity
    private Rigidbody hitboxRb;
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
        meleeHitbox = meleeWeaponHB.GetComponent<BoxCollider>();
        meleeHitbox.enabled = false;
        //Get Rigidbody
        hitboxRb = meleeWeaponHB.GetComponent<Rigidbody>();
    }

    public void Strike()
    {
        //Activate Collider for Swing
        meleeHitbox.enabled = true;
        swing = true;
        hitboxRb.transform.position = weaponLoc.position;
        hitboxRb.transform.rotation = weaponLoc.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        //Start the hitbox timer
        if(swing==true)
        {
            //Keeps track of frames
            cycle = cycle + 1;
            hitboxRb.transform.position = weaponLoc.position;
            hitboxRb.transform.rotation = weaponLoc.rotation;
        }
        if (cycle>=attackSpeed)
        {
            swing = false;
            cycle = 0;
            meleeHitbox.enabled = false;
            hitboxRb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            hitboxRb.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            hitboxRb.transform.position = weaponLoc.position;
            hitboxRb.transform.rotation = weaponLoc.rotation;
        }
    }
}