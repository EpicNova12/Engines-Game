using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Enemy u_enemy;

    //Hp
    public float hpMax;
    private float hp;

    // Start is called before the first frame update
    void Start()
    {
        u_enemy = this;
        u_enemy.hp=u_enemy.hpMax;
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
        Debug.Log(u_enemy.hp);
    }

    public float GetHP()
    {
        return u_enemy.hp;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            TakeDamage(Shooting.instance.damageReg);
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.tag == "Weapon")
        {
            TakeDamage(Melee.instance.damageReg);
        }
    }
}
