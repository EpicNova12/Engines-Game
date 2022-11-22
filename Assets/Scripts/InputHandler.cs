using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    Command OpenMenu = new OpenMenuCommand();
    Command Jump = new JumpCommand();
    Command Shoot = new ShootCommand();
    Command Melee = new MeleeCommand();
    Command Reload = new ReloadCommand();

    private void Awake()
    {
        //Sets up default key config
        OpenMenu.key = KeyCode.Escape;
        Jump.key= KeyCode.Space;
        Shoot.key = KeyCode.Mouse0;
        Melee.key = KeyCode.Mouse1;
        Reload.key = KeyCode.R;
    }
    private void Update()
    {
        //Jump
        if (Input.GetKeyDown(OpenMenu.key))
        {
            OpenMenu.Execute();
        }
        //Jump
        if (Input.GetKeyDown(Jump.key))
        {
            Jump.Execute();
        }
        //Shoot
        if (Input.GetKeyDown(Shoot.key))
        {
            Shoot.Execute();
        }
        //Melee
        if (Input.GetKeyDown(Melee.key))
        {
            Melee.Execute();
        }
        //Reload
        if(Input.GetKeyDown(Reload.key))
        {
            Reload.Execute();
        }
    }
}
