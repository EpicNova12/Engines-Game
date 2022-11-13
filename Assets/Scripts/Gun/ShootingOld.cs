using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingOld : MonoBehaviour
{
    //Instance
    public static ShootingOld instance;

    //Gun
    public GameObject Gun;

    //Bullets
    public GameObject bullet;
    public Transform bulletSpawn;
    public float bulletSpeed = 20.0f;
    //Awake
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Shoot()
    {
        var bulletCreate = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        bulletCreate.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
        Destroy(bulletCreate, 1);
    }

    private void Update()
    {

    }
}
//Shooting code from
//https://youtu.be/wZ2UUOC17AY