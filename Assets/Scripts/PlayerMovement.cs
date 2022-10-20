using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class PlayerMovement : MonoBehaviour
{
    //Import DLL
    //DLL will allow the user to alter the players attributes
    [DllImport("StatsPlugin")]
    private static extern float LoadFromFile(int j, string fileName);
    [DllImport("StatsPlugin")]
    private static extern int GetLines(string fileName);

    string m_file;

    //Instance
    public static PlayerMovement instance;
    //Rigidbody
    [Header("Player")]
    private Rigidbody playerBody;
    public float playerHeight;
    public LayerMask checkGround;
    bool isGrounded;

    //Animator
    //private Animator animator;

    //Oritentation and Input
    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    //Speed and Drag
    [Header("Speed")]
    public float playerSpeed;
    public float groundDrag;
    public float airDrag;
    Vector3 m_direction;

    //Jumping
    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    private bool canJump = true;
    public float airMultiplier;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        m_file = Application.dataPath + "/PlayerStats";
        playerBody = GetComponent<Rigidbody>();
        playerBody.freezeRotation = true;

        GetCustomStats();

       // animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Check if player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, checkGround);

        if(isGrounded)
        {
            playerBody.drag = groundDrag;
        }
        else
        {
            playerBody.drag = 0.0f;
        }
        GetInput();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        SpeedControl();
       // animator.SetFloat("Moving", v);
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Jump Input done with Command Input

    }

    private void MovePlayer()
    {
        m_direction = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (isGrounded)
        {
            playerBody.AddForce(m_direction.normalized * playerSpeed * 10.0f, ForceMode.Force);
        }

        if (!isGrounded)
        {
            playerBody.AddForce(m_direction.normalized * playerSpeed * 10.0f* airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(playerBody.velocity.x, 0.0f, playerBody.velocity.z);

        if(flatVel.magnitude>playerSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * playerSpeed;
            playerBody.velocity = new Vector3(limitedVel.x, playerBody.velocity.y, limitedVel.z);
        }
    }

    public void Jump()
    {
        if (canJump && isGrounded)
        {
            canJump = false;

            playerBody.velocity = new Vector3(playerBody.velocity.x, 0.0f, playerBody.velocity.z);

            playerBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            Invoke(nameof(ResetJump), jumpCooldown);

        }
    }

    private void ResetJump()
    {
        canJump = true;
    }

    void GetCustomStats()
    {
        //Speed
        playerSpeed = LoadFromFile(5, m_file);
        groundDrag = LoadFromFile(7, m_file);
        airDrag = LoadFromFile(9, m_file);

        //Jump
        jumpForce = LoadFromFile(13, m_file);
        jumpCooldown = LoadFromFile(15, m_file);
        airMultiplier = LoadFromFile(17, m_file);
    }
}

//Camera and movement code from
//https://youtu.be/f473C43s8nE