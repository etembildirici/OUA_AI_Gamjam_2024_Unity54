
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [Header("Player Movement")]
    public float playerSpeed = 6f;

    [Header("Player Calm Time")]
    public float turnCalmTime = 0.1f;
    float turnCalmVelocity;

    [Header("Player Script Camera")]
    public Transform playerCam;

    [Header("Player Animator and Gravity")]
    public CharacterController controller;
    public float gravity = -9.81f;
    public Animator anim;

    [Header("Player jumping and velocity")]
    public float jumpForce = 0.1f;
    Vector3 vel;
    public Transform groundCheck;
    private bool isGround;
    public LayerMask groundLayer;
    public float groundDistance = 0.4f;

    [Header("Time")]
    public TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGround && vel.y < 0)
        {
            vel.y = -2f;
        }

        vel.y += gravity * Time.deltaTime;
        controller.Move(vel * Time.deltaTime);

        playerMove();
        Jump();
        SlowDown();
    }
    void playerMove()
    {
        float horizontal_axis = Input.GetAxisRaw("Horizontal");
        float vertical_axis = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(horizontal_axis, 0f, vertical_axis).normalized;
        //transform.Translate(direction * playerSpeed * Time.unscaledDeltaTime, Space.World);
        //Vector3 direction = new Vector3(horizontal_axis, 0, vertical_axis) * playerSpeed * Time.unscaledDeltaTime;
        //transform.Translate(direction, Space.World);

        anim.speed = 1f / Time.timeScale;

        if (direction.magnitude >= 0.1f)
        {

            anim.SetBool("Run", true);
            anim.SetBool("Idle", false);
            anim.SetTrigger("Jump");
            anim.SetBool("AimWalk", false);
            anim.SetBool("IdleAim", false);


            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * playerSpeed * Time.unscaledDeltaTime);
        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetTrigger("Jump");
            anim.SetBool("Run", false);
            anim.SetBool("AimWalk", false);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            anim.SetBool("Run", false);
            vel.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }
        else
        {
            anim.ResetTrigger("Jump");
        }
    }
    void SlowDown()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            timeManager.DoSlowmotion();
        }
    }
}