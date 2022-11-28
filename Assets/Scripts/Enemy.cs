using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    Enemy u_enemy;

    //Hp
    public float hpMax;
    private float hp;

    public TMP_Text displayHealth;

    // Start is called before the first frame update
    void Start()
    {
        u_enemy = this;
        u_enemy.hp=u_enemy.hpMax;
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        u_enemy.hp = u_enemy.hp - damage;
        //If HP Runs out
        if(u_enemy.hp <= 0 )
        {
            Destroy(gameObject);
        }
        //Debug.Log(u_enemy.hp);
    }

    public float GetHP()
    {
        return u_enemy.hp;
    }

   private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            if (Shooting.instance.BuffAttack() == true)
            {
                TakeDamage(Shooting.instance.damageBuff);
                Shooting.instance.RemoveBuff();
            }
            else if (Shooting.instance.BuffAttack() == false)
            {
                TakeDamage(Shooting.instance.damageReg);
            }

            Melee.instance.AddBuff();

            Debug.Log("Melee Buff: " + Melee.instance.buffStack);
            other.gameObject.SetActive(false);
            UpdateDisplay();
        }

        if (other.gameObject.tag == "Weapon")
        {
            if (Melee.instance.BuffAttack() == true)
            {
                TakeDamage(Melee.instance.damageBuff);
                Melee.instance.RemoveBuff();
                Debug.Log("Swish");
            }
            else if (Melee.instance.BuffAttack() == false)
            {
                TakeDamage(Melee.instance.damageReg);
            }
            Debug.Log(Melee.instance.BuffAttack());

            Shooting.instance.BuffBullet();
            Debug.Log("Ammo Buff: " + Shooting.instance.ammoBuff);
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        displayHealth.text = hp.ToString() ;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(Shooting.instance.damageReg);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Weapon")
        {
            TakeDamage(Melee.instance.damageReg);
        }
    }*/
}
