using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    public float movementSpeed;
    public float moveToStopRate;
    public float stopToMoveRate;
    public float moveToSprintRate;
    public float sprintSpeed;
    public float sprintToMoveRate;
    public float rotationSpeed;
    public float moveAnimationSmoothTime;
    public float sprintAnimationSmoothTime;

    [Space, Header("Jump Variables")]
    public float jumpForce;
    public float distToGround = 1.1f;
    public float gravity;
    public LayerMask ground;

    float speed;
    float horizontal;
    float vertical;

    float horizontal2;

    float xRotationValue;

    Vector3 direction;
    Quaternion rotation;
    Camera cam;

    bool isJumping;
    bool isSprinting;

    Rigidbody rb;
    Animator anim;

    public static bool inAir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        RecieveInput();
    }

    private void LateUpdate()
    {
        Movement();
        Rotate();
        Jump();

        if (!Grounded())
        {
            inAir = true;
            Fall();
        }
        else
            inAir = false;
    }

    void RecieveInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        horizontal2 = Input.GetAxis("Mouse X");

        vertical = Input.GetAxis("Vertical");

        isJumping = Input.GetKeyDown(KeyCode.Space);
        isSprinting = Input.GetKey(KeyCode.LeftShift);
    }

    void Movement()
    {
        direction = new Vector3(horizontal, 0, vertical);

        if (direction != Vector3.zero)
        {
            if (isSprinting && speed < sprintSpeed)
                speed += moveToSprintRate * Time.deltaTime;
            else if (speed < movementSpeed)
                speed += stopToMoveRate * Time.deltaTime;
            else if (speed > movementSpeed)
                speed -= sprintToMoveRate * Time.deltaTime;
        }
        else if (speed > 0)
            speed -= moveToStopRate * Time.deltaTime;

        direction *= speed;
        direction = cam.transform.TransformDirection(direction);
        rb.velocity = new Vector3(direction.x, rb.velocity.y, direction.z);

        if(!isSprinting)
            anim.SetFloat("Speed", speed, moveAnimationSmoothTime, Time.deltaTime);
        else
            anim.SetFloat("Speed", speed, sprintAnimationSmoothTime, Time.deltaTime);

        anim.SetInteger("VerticalVelocity", (int)rb.velocity.y  * 2);
        anim.SetBool("InAir", inAir);
    }

    void Rotate()
    {
        //xRotationValue -= -horizontal2 * rotationSpeed * Time.deltaTime;
        //rotation = Quaternion.Euler(0, xRotationValue, 0);
        //transform.rotation = rotation;


        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        transform.rotation = Quaternion.LookRotation(targetDirection);
    }

    void Jump()
    {
        if (isJumping && Grounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    void Fall()
    {
        rb.velocity += Physics.gravity * gravity * Time.fixedDeltaTime;
    }

    bool Grounded()
    {
        return Physics.OverlapSphere(transform.position, distToGround, ground).Length > 0;
    }
}

