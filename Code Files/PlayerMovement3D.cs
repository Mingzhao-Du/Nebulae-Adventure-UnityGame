using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float autoMoveSpeed = 2f;
    private Vector3 moveDirection;
    private Vector3 velocity;
    private Transform cameraTransform;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;

        if (controller == null)
            Debug.LogError("The CharacterController component is missing.");

        if (cameraTransform == null)
            Debug.LogError("The main camera was not found.");
    }

    void Update()
    {
        HandleAllMovement();  // Make sure all movement logic is handled per frame
    }

    // 处理所有的移动逻辑
    public void HandleAllMovement()
    {
        HandleAutoMove();
        ApplyGravity();

        Vector3 horizontalMovement = moveDirection * movementSpeed;
        Vector3 finalVelocity = new Vector3(horizontalMovement.x, velocity.y, horizontalMovement.z);
        controller.Move(finalVelocity * Time.deltaTime);
    }

    private void HandleAutoMove()
    {
        moveDirection = transform.forward * autoMoveSpeed;
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }
        velocity.y += -9.81f * Time.deltaTime;
    }
}