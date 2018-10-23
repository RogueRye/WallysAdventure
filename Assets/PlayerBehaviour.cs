using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {


    public GameObject graphics;
    public CameraFollow camController;


    [Header("Stats")]
    public float jumpForce = 6;
    public float jumpForward = 7;
    public float moveSpeed; 


    [Header("Info")]
    public Transform groundPoint;
    [Range(0, 1)]
    public float radius;
    public LayerMask groundMask;


    public bool grounded = false;
    bool jumpInput;
    Rigidbody2D rb;
    Animator anim;
    private bool isSprinting;
    bool canJump = true;
    float inputH = 0;
    Vector2 moveDir;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = graphics.GetComponent<Animator>();
        camController.Init();
	}
	

	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

        Move();

        if (grounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        HandleAnimStates();
        camController.Tick();
    }

    void HandleAnimStates()
    {
        anim.SetBool("falling", rb.velocity.y < 0);
        anim.SetBool("inAir", !grounded);

    }
    public void Move()
    {
        if (!anim.GetBool("canMove"))
            return;

        inputH = Input.GetAxisRaw("Horizontal");

        moveDir =  new Vector2(inputH * moveSpeed, rb.velocity.y);

        if (moveDir.x != 0)
        {
            anim.SetBool("isMoving", true);
            float lookDir = 0;
            if (moveDir.x > 0)
            {
                lookDir = 0; // look right
            }
            else if (moveDir.x < 0)
            {
                lookDir = 180; //look left
            }

            var targetRot = Quaternion.Euler(Vector3.up * lookDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 10);

  
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        


    }

    public void Push()
    {
        rb.AddForce(moveDir, ForceMode2D.Impulse);
    }

    public void Jump()
    {

        anim.Play("Jump");

        rb.AddForce((moveDir * jumpForward) + (Vector2.up * jumpForce), ForceMode2D.Impulse);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPoint.position, radius);
    }
}
