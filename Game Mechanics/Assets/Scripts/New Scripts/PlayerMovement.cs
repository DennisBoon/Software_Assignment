using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float jumpSpeed = 6.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public bool controllable = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Player movement
        if (controller.isGrounded && controllable)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            // Player speed
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                moveDirection *= sprintSpeed;
            }
            else
            {
                moveDirection *= speed;
            }

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
