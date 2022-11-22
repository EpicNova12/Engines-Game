using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public int cycleTimer;
    private int cycle;
    // Start is called before the first frame update
    void Start()
    {
        cycle = 0;
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        cycle = cycle + 1;
        if(cycle >=cycleTimer)
        {
            gameObject.SetActive(false);
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            cycle= 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Weapon")
        {
            gameObject.SetActive(false);
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        /*if(other.collider.tag == "Enemy")
        {
            FindObjectOfType<Enemy>().TakeDamage(Shooting.instance.damageReg);

            if(FindObjectOfType<Enemy>().GetHP() <=0)
            {
                Destroy(other.gameObject);
            }
        }*/
    }
}
