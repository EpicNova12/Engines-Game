using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

   // public PlayerHealth m_PlayerHealth;
    //public PlayerMovement m_PlayerMovement;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
       // m_PlayerHealth = gameObject.GetComponent<PlayerHealth>();
       // m_PlayerMovement = gameObject.GetComponent<PlayerMovement>();
    }
}
