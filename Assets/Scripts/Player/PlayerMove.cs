
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float leftRightSpeed = 4f;
    public float jumpHeight = 3.5f;
    public float gravity = -20f;

    private CharacterController controller;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            horizontal = -1f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            horizontal = 1f;

        Vector3 movement = Vector3.forward * moveSpeed;

        movement += Vector3.right * horizontal * leftRightSpeed;

        if (controller != null)
        {
            if (controller.isGrounded)
            {
                verticalVelocity = -1f;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
            }

            verticalVelocity += gravity * Time.deltaTime;
            movement.y = verticalVelocity;

            controller.Move(movement * Time.deltaTime);
        }
        else
        {
            transform.Translate(
                Vector3.forward * moveSpeed * Time.deltaTime,
                Space.World
            );
        }
    }
}
