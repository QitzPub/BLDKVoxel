using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float gravity;
    [SerializeField] float jumpPower;

    private CharacterController controller;
    private Vector3 verticalVelocity = Vector3.zero;
    private Vector3 horizontalVelocity = Vector3.zero;
    private Vector3 rotation = Vector3.back;

    private Vector3 forwardRotation = Vector3.forward;
    private Vector3 backRotation = Vector3.back;
    private Vector3 leftRotation = Vector3.left;
    private Vector3 rightRotation = Vector3.right;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                verticalVelocity = Vector3.up * jumpPower;
            }
        }
        else
        {
            verticalVelocity += Vector3.down * gravity * Time.deltaTime;
        }

        rotation = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            rotation += forwardRotation;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotation += leftRotation;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rotation += backRotation;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation += rightRotation;
        }
        if (rotation != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(rotation);
            horizontalVelocity = transform.forward * speed * Time.deltaTime;
            controller.Move(verticalVelocity + horizontalVelocity);
        }
        else
        {
            controller.Move(verticalVelocity);
        }
    }
}