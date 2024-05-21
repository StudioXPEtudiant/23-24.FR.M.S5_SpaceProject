using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform orientation;
    public Transform playerCam;

    public Animator animator;

    public float walkSpeed = 100;

    private Rigidbody rb;

    private bool cursorLocked = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && cursorLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cursorLocked = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cursorLocked = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = orientation.forward * Input.GetAxis("Vertical") + orientation.right * Input.GetAxis("Horizontal");
        
        rb.AddForce(moveDirection * walkSpeed);
        
        transform.rotation = Quaternion.Euler(0, playerCam.rotation.eulerAngles.y, 0);

        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }
}
