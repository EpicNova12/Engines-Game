using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other != null) { Debug.Log("Yeetus"); }
        if(other.gameObject.tag == "Enemy")
        {
            FindObjectOfType<Enemy>().TakeDamage(Melee.instance.damageReg);

            if (FindObjectOfType<Enemy>().GetHP() <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
