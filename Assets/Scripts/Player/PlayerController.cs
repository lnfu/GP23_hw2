using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;
    public float gravity;
    public float jumpHeight;
    public bool isGrounded;
    public float groundCheckDistance;
    public Transform foot;
    //public LayerMask groundMask;

    private Vector3 moveDirection;
    private Vector3 velocity;
    private CharacterController characterController;
    private Animator anim;
    public float angle;



    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        angle = 0;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(foot.position, Vector3.down, groundCheckDistance);
        //Debug.DrawRay(foot.position, Vector3.down*groundCheckDistance);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        Move();

        if (isGrounded)
        {
            Jump();

        }
        velocity.y += gravity * Time.deltaTime;
        //characterController.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("Attack");
        }

    }
    private void Move()
    {

        float moveZ = Input.GetAxis("Vertical");
        float rot = Input.GetAxis("Horizontal");
        anim.SetFloat("Velocity", moveZ);
        //moveDirection *= moveSpeed;
        // print(moveDirection);
        //characterController.SimpleMove(moveDirection);
        //         if(moveZ != 0)
        angle += rot * Time.deltaTime;
        //         {

        // Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        Quaternion toRotation = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = Quaternion.EulerRotation(new Vector3(0, angle, 0));
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed * Time.deltaTime);

        moveDirection = new Vector3(0, 0, moveZ);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        //         }
    }


    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("jump");
            anim.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

    }





}

