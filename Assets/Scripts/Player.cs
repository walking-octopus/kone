using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool invertPlayers;

    public GameObject player1;
    public GameObject player2;

    public float movementSpeed;
    public float jumpForce;
    public int extraJumps;
    private int extraJumpValue;

    private bool isGround;
    public Transform groundCheck; 
    public float checkRadius;
    public LayerMask whatIsGround;
    
    private Rigidbody2D rb1;
    private Rigidbody2D rb2;
    

    void Start()
    {
        rb1 = player1.GetComponent<Rigidbody2D>();
        rb2 = player2.GetComponent<Rigidbody2D>();
        extraJumpValue = extraJumps;
    }

    void Update() {
        if (isGround) {
            extraJumpValue = extraJumps;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumpValue > 0) {
            rb1.velocity = Vector2.up * jumpForce;
            rb2.velocity = Vector2.down * jumpForce;
            extraJumpValue--;
        }
    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        float horizontalInput = Input.GetAxis("Horizontal");
        float JumpInput = Input.GetAxis("Jump");

        if (invertPlayers) {
            rb2.velocity = new Vector2(horizontalInput * movementSpeed, rb2.velocity.y);
            rb1.velocity = new Vector2(-horizontalInput * movementSpeed, rb1.velocity.y);
        } else {
            rb1.velocity = new Vector2(horizontalInput * movementSpeed, rb1.velocity.y);
            rb2.velocity = new Vector2(-horizontalInput * movementSpeed, rb2.velocity.y);
        }
    }
}
