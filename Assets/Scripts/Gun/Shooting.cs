using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Instance
    public static Shooting instance;

    //Gun
    public Transform Gun;
    public float damageReg;
    public float damageBuff;

    //Bullets
    public GameObject bullet;
    public Transform bulletSpawn;
    public float bulletSpeed;

    int ammo;
    public int ammoMax;

    //Awake
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        ammo = ammoMax;
    }

    public void Shoot()
    {
        //Expend ammo
        ammo = ammo - 1;
        if (ammo >= 0)
        {
            Rigidbody bulletRb = ObjectPooler.instance.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation).GetComponent<Rigidbody>();
            bulletRb.AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
        }
        //Debug.Log(ammo);
    }

    //Reload Function
    public void Reload()
    {
        ammo = ammoMax;
    }

    public bool CheckAmmo()
    {
        if(ammo<=0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private void Update()
    {
       
    }
}