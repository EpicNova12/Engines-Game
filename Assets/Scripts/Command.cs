using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public KeyCode key;
    public abstract void Execute();
}

public class Empty: Command
{
    public override void Execute()
    {
        //Empty();
    }
}
public class OpenMenuCommand : Command
{
    public override void Execute()
    {
        MenuControl.instance.OpenMenu();
    }
}
public class JumpCommand: Command
{
    public override void Execute()
    {
        PlayerMovement.instance.Jump();
    }
}
public class ShootCommand : Command
{
    public override void Execute()
    {
        Shooting.instance.Shoot();
    }
}
public class MeleeCommand : Command
{
    public override void Execute()
    {
        Melee.instance.Strike();
    }
}
public class ReloadCommand : Command
{
    public override void Execute()
    {
        Shooting.instance.Reload();
    }
}