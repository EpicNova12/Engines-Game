using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    public int ammoBuff;
    public int ammoMax;

    //Get ammo display
    public TMP_Text displayAmmo;
    //Get buff display
    public TMP_Text displayBuff;

    //Awake
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        ammo = ammoMax;
        ammoBuff = 0;
        UpdateDisplayAmmo();
    }

    public void Shoot()
    {
        //Expend ammo
        if (ammo >= 1)
        {
            ammo = ammo - 1;
            Rigidbody bulletRb = ObjectPooler.instance.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation).GetComponent<Rigidbody>();
            bulletRb.AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
        }
        UpdateDisplayAmmo();
        //Debug.Log(ammo);
    }

    //Reload Function
    public void Reload()
    {
        ammo = ammoMax;
        UpdateDisplayAmmo();
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
    //Buff nest shot
    public void BuffBullet()
    {
        if(ammoBuff<6)
        {
            ammoBuff = ammoBuff + 1;
        }
        UpdateDisplayBuff();
    }

    public void RemoveBuff()
    {
        ammoBuff = ammoBuff - 1;
        UpdateDisplayBuff();
    }

    public bool BuffAttack()
    {
        if(ammoBuff>=1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Update()
    {
       
    }
    //Update the ammo counter
    private void UpdateDisplayAmmo()
    {
        displayAmmo.text = ammo.ToString();
    }
    private void UpdateDisplayBuff()
    {
        displayBuff.text = ammoBuff.ToString();
    }
}