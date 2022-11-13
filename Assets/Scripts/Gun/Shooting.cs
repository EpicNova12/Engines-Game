using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Instance
    public static Shooting instance;

    //Gun
    public Transform Gun;
    
    //Bullets
    public GameObject bullet;
    public Transform bulletSpawn;
    public float bulletSpeed = 20.0f;

    //Awake
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Shoot()
    {
        Rigidbody bulletRb = ObjectPooler.instance.SpawnFromPool("Bullet",Gun.position+new Vector3(0.0f,0.0f,-1.5f),Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * -bulletSpeed, ForceMode.Impulse);
    }

    private void Update()
    {
       
    }
}