using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {


    public GameObject graphics;
    public CameraFollow camController;


    [Header("Stats")]
    public float jumpForce = 6;


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
    private float moveSpeed;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = graphics.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);
    }


    private void Move()
    {

        float inputH = Input.GetAxisRaw("Horizontal");

        Vector2 moveDir =  new Vector2(inputH * moveSpeed, rb.velocity.y);
        rb.velocity = moveDir;



        if (moveDir.x != 0)
        {
            anim.SetBool("isMoving", true);
            Vector3 lookDir;
            if (moveDir.x > 0)
            {
                lookDir = Vector2.right;
            }
            else if (moveDir.x < 0)
            {
                lookDir = Vector2.left;
            }


        }
        else
        {
            anim.SetBool("isMoving", false);
        }




    }
}
