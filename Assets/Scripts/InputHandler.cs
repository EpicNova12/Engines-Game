using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //Using a singleton to keep things simple, since input handler is a game system, having it as a singleton will make sure there is only ever one
    public static InputHandler instance;

    Command OpenMenu = new OpenMenuCommand();
    Command Jump = new JumpCommand();
    Command Shoot = new ShootCommand();
    Command Melee = new MeleeCommand();
    Command Reload = new ReloadCommand();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
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
    public void SwapKeys(string u_command, KeyCode newKey)
    {
        //Hopefully replace with ENUMS if I have time
        if(u_command == "Jump")
        {
            Jump.key = newKey;
        }
        else if (u_command == "Shoot")
        {
            Shoot.key = newKey;
        }
        else if (u_command == "Melee")
        {
            Melee.key = newKey;
        }
        else if (u_command == "Reload")
        {
            Reload.key = newKey;
        }
    }
    public void SetDefault()
    {
        OpenMenu.key = KeyCode.Escape;
        Jump.key = KeyCode.Space;
        Shoot.key = KeyCode.Mouse0;
        Melee.key = KeyCode.Mouse1;
        Reload.key = KeyCode.R;
    }
}
