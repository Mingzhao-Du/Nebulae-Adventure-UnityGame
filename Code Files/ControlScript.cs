using System.Collections;
using System.IO.Ports;
using UnityEngine;

public class ArduinoController : MonoBehaviour
{
    SerialPort serial = new SerialPort("COM6", 9600);
    public float moveSpeed = 5f;       // Movement speed
    public float jumpForce = 30f;       // Jump strength
    public float gravity = 60f;      // gravitational acceleration

    private CharacterController controller;
    private Vector3 velocity;          // Character's current speed
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        serial.Open();
        serial.ReadTimeout = 50;
    }

    void Update()
    {
        if (serial.IsOpen)
        {
            try
            {
                string data = serial.ReadLine().Trim();
                Debug.Log(data);

                if (data == "LEFT")
                {
                    MoveLeft();
                }
                else if (data == "RIGHT")
                {
                    MoveRight();
                }
                else if (data == "JUMP")
                {
                    Jump();
                }
            }
            catch (System.Exception)
            {
                // Read timeout ignore error
            }
        }

        ApplyGravity();
    }

    void MoveLeft()
    {
        Vector3 move = Vector3.left * moveSpeed * Time.deltaTime;
        controller.Move(move);
    }

    void MoveRight()
    {
        Vector3 move = Vector3.right * moveSpeed * Time.deltaTime;
        controller.Move(move);
    }

    void Jump()
    {
        // Check if the character is in contact with the ground
        isGrounded = controller.isGrounded;  

        if (isGrounded)
        {
            velocity.y = jumpForce;
        }
        else
        {
            // Adjust gravity or jump behavior if the character is not on the ground
            velocity.y = Mathf.Max(velocity.y, -gravity);
        }
    }

    void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Use a more suitable ground speed to avoid floating
        }

        // Apply gravitational acceleration
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
