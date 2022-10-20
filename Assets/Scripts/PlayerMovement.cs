using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
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
        playerBody = GetComponent<Rigidbody>();
        playerBody.freezeRotation = true;

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
}

//Camera and movement code from
//https://youtu.be/f473C43s8nE