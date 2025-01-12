using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Dodge")]
    public float dodgeDuration = 1f;
    public KeyCode dodgeKey = KeyCode.F;

    public KeyCode slamKey = KeyCode.S;

    //Private variables
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private bool isDodging = false;

    public GameObject TimeManager;
    //private Animator anim;
    [HideInInspector]
    public bool facingRight;
    private bool hasLetGo = false;

    [Header("Health")]
    public float health = 2;
    public float regenTime = 5;

    [Header("Movement")]
    public float maxSpeed;
    public float climbSpeed;
    private float moveInputVertical;
    private float moveInput;
    private float speed=0;


    /*[Header("Vault")]
    public Transform ledgeCheckRight;
    public Transform ledgeCheckLeft;
    private Transform ledgeCheck;
    public float checkRadius;
    public LayerMask whatIsLedge;
    private bool isNextToLegde;*/

    [Header("Ground")]
    //Ground
    public Transform groundCheck;
    public float checkRadiusGround;
    public LayerMask whatIsGround;
    public bool isGrounded;

    [Header("Jump")]
    public int maxJumps = 2;
    public float jumpForce = 2;
    public int jumps;

    /*[Header("Wall Jump/Climb")]
    //Wall Jump
    private float wallJumpTime;
    public float wallJumpTimeMax;
    private bool isWallJumping = false;
    //Wall Hang
    private bool isHanging = false;
    public Image grabBar;
    public float maxGrabStamina = 100;
    private float grabStamina;*/


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        jumps = maxJumps;
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //grabStamina = maxGrabStamina;
        //wallJumpTime = wallJumpTimeMax;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && !isDodging)
        {
            StopCoroutine(HealthRegen());
            if(health==2)
            {
                StartCoroutine(HealthRegen());
            }
            health -= 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Fail"))
        {
            health = 0;
        }
    }

    public void BarrelDamage()
    {
        health -= 1f;
    }

    void FixedUpdate()
    {
        //Ground Slam
        if(!isGrounded && Input.GetKey(slamKey))
        {
            rb.velocity = Vector2.up * jumpForce * -2;
        }

        if(health <= 0)
        {
            Time.timeScale = 0.0f;
            TimeManager.SetActive(false);
        }
        
        if(Input.GetKeyDown(dodgeKey) && !isDodging)
        {
            StartCoroutine(Dodge());
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadiusGround, whatIsGround);

        //Moving
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * maxSpeed, rb.velocity.y);
            //To do: SpeedLerping

        //Sprite Flip
        if(facingRight && moveInput > 0)
        {
            facingRight = !facingRight;
            sprite.flipX = false;
        }
        else if(!facingRight && moveInput < 0)
        {
            facingRight = !facingRight;
            sprite.flipX = true;
        }

       

        //Jumping
        if(Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumps--;
        }
        

        if (isGrounded)
        {
            jumps = maxJumps;
            //anim.SetBool("IsJumping", false);
        }

        //Wall Jumping
        /*
        if (isHanging && Input.GetKey(KeyCode.Space))
        {
            hasLetGo = true;
            rb.velocity = Vector2.up * jumpForce;
            isWallJumping = true;
            grabStamina -= 10;
        }

        if (isWallJumping)
        {
            hasLetGo = true;
            if (wallJumpTime <= 0)
            {
                hasLetGo = false;
                wallJumpTime = wallJumpTimeMax;
                isWallJumping = false;
            }
            else
            {
                wallJumpTime -= Time.deltaTime;
            }
        }

        //Wall Hanging
        if (Input.GetKey(KeyCode.Mouse1) && isNextToLegde && !isGrounded && !hasLetGo)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            isHanging = true;
        }
        else
        {
            hasLetGo = true;
        }

        if (hasLetGo)
        {
            isHanging = false;
            rb.gravityScale = 1;
        }

        //Wall Climbing
        if(isHanging)
        {
            moveInputVertical = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, moveInputVertical * climbSpeed);
        }*/
    }

    IEnumerator Dodge()
    {
        isDodging = true;
        sprite.color = Color.black;
        yield return new WaitForSeconds(dodgeDuration);
        isDodging = false;
        sprite.color = Color.white;
    }

    IEnumerator HealthRegen()
    {
        yield return new WaitForSeconds(regenTime);
        health += 1;
    }

    /*IEnumerator SpeedLerping()
    {
        speed = Mathf.LerpUnclamped(speed, maxSpeed, 2);
        yield return new WaitForSeconds(0.5f);
    }*/
}
