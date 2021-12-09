using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    private Animator anim;
    private Collider2D collider;

    //Health
    public float Health;

    //Feet
    private bool isGround;
    public Transform Feet;
    public float checkRadius;

    //Frount
    public Transform Frount;
    public bool isFrount;
    public bool WallSliding;
    public float wallSlidingSpeed;

    //jump
    public LayerMask Ground;
    public float speed = 5f;
    public float jumpForce = 10f;

    //wallJumping
    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float walljumpTime;

    //colectibles
    public int Cherryies = 0;

    //calling Animations
    private enum State { idle, run, jump, falling, crouch, climb, hurt, Collection }
    private State state = State.idle;

    //Calling Chest Animations
    private enum State1 { closed, open}
    private State1 state1 = State1.closed;

    



    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");
        //float vDirection = Input.GetAxis("Jump");

        //Movement Controller
        if (hDirection > 0 )
        {

            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            

        }

        else if (hDirection < 0) 
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            //transform.localScale = new Vector2(1, 1);
        }

        //Jumping control
        isGround = Physics2D.OverlapCircle(Feet.position, checkRadius, Ground);

        if (Input.GetButtonDown("Jump") && isGround == true /*collider.IsTouchingLayers(isGround)*/)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jump;

        }

        //wall jump derection
        //sliding down wall

        isFrount = Physics2D.OverlapCircle(Frount.position, checkRadius, Ground);

        if(isFrount == true && isGround == false && hDirection != 0)
        {
            WallSliding = true;
        }
        else
        {
            WallSliding = false;
        }

        if (WallSliding)
        {
            

            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue) );
        }

        if (Input.GetButtonDown("Jump") && WallSliding == true)
        {

            //rb.velocity = new Vector2(xWallForce * -hDirection, jumpForce);
            //state = State.jump;
            
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", walljumpTime);

        }
        if(wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -hDirection, yWallForce);
            state = State.jump;
            // rb.velocity = new Vector2(xWallForce * , yWallForce);
            
        }

    


    //Methods
    VelocityState();
        anim.SetInteger("State", (int)state);

    }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }


    //Collectibles cherry

    //public Animator Collection;
    //public AnimationClip Item_CollectionClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectible")
        {
            
            state = State.Collection;
            
            Cherryies += 1;

            if(state == State.Collection)
            {
                //Collection.Play("Item_Collection");
                Destroy(collision.gameObject/*, Item_CollectionClip.length*/);
            }
        }

        if(collision.tag == "Chest")
        {
            
            
        }
    }

    //Falling on enemy control

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && state == State.falling)
        {
            Destroy(collision.gameObject);
            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jump;
        }
    }



    //Animation controller
    private void VelocityState()
    {
        if (state == State.jump)
        {
            if (rb.velocity.y < 0.1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (collider.IsTouchingLayers(Ground))
            {
                state = State.idle;
            }

        }


        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.run;
        }

        else
        {
            state = State.idle;
        }


    }


}
