using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles player movement
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private CharacterController character;
    [SerializeField]
    private Transform cam;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float sprintSpeed;
    [SerializeField]
    private float camSensitivity;
    [SerializeField]
    private float maxAngle;
    [SerializeField]
    private bool invert;


    private void Start()
    {
        character = GetComponent<CharacterController>();
    }


    /// <summary>
    /// Handles camera movement
    /// </summary>
    private void Update()
    {
        Vector2 mouseMove = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        mouseMove *= camSensitivity;

        if (!invert)
        {
            mouseMove.y *= -1;
        }
        
        transform.Rotate(new Vector3(0, mouseMove.x, 0));

        float angle = cam.rotation.eulerAngles.x;

        if (angle > 180)
        {
            angle -= 360;
        }

        if (!(angle + mouseMove.y > maxAngle) && !(angle + mouseMove.y < -maxAngle))
        {
            cam.Rotate(new Vector3(mouseMove.y, 0, 0));
        }
    }

    /// <summary>
    /// Handles player movement
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            dir -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            dir += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir -= transform.right;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            character.Move(dir * sprintSpeed);
        }

        else
        {
            character.Move(dir * walkSpeed);
        }
    }
}
