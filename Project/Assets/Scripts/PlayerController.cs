using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    private Animator anim;
    private Collider2D collider;

    //Health
    public float Health = 3;

    //Hurt
    public float hurtBounce = 10f;

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
    public int Coins = 0;

    //calling Animations
    private enum State { idle, run, jump, falling, crouch, climb, hurt, Collection, death }
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

        if (state != State.hurt)
        {
            if (state != State.death)
            {
                Movement();
            }

        }
        
        else { }




        //Methods
        PlayerDeath();
        VelocityState();
        anim.SetInteger("State", (int)state);

    }

    
    //death controler

    public void PlayerDeath()
    {
        if (Health < 0)
        {
            state = State.death;

        }

        if (state == State.death)
        {

        }
    }

    //Collectibles cherry

    //public Animator Collection;
    //public AnimationClip Item_CollectionClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cherry cconlection
        if(collision.tag == "Cherry")
        {
            
            state = State.Collection;
            
            Cherryies += 1;

            if(state == State.Collection)
            {
                //Collection.Play("Item_Collection");
                Destroy(collision.gameObject/*, Item_CollectionClip.length*/);
            }
        }

        //coin collection
        if (collision.tag == "Coin")
        {

            state = State.Collection;

            Coins += 1;

            if (state == State.Collection)
            {
                //Collection.Play("Item_Collection");
                Destroy(collision.gameObject/*, Item_CollectionClip.length*/);
            }
        }


        //Deathzone
        if (collision.tag == "DeathZone")
        {
            state = State.death;

        }
    }

    //Falling on enemy control

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" )
        {
            
            
            if (state == State.falling)
            {
                Destroy(other.gameObject);

                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                state = State.jump;
            }
            else
            {
                
                state = State.hurt;
                Health = Health - 1;
                
                /*if (other.gameObject.transform.position.x > transform.position.x)
                {
                    //enemy is to the right
                    rb.velocity = new Vector2(-hurtBounce, rb.velocity.y);
                }
                else
                {
                    //enemy is to the left
                    rb.velocity = new Vector2(hurtBounce, rb.velocity.y);
                }*/

            }
        }
        else { }
    }

    //Player Death controler
    


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


    //Movement controler
    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");
        //float vDirection = Input.GetAxis("Jump");

        //Movement Controller
        if (hDirection > 0)
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

        if (isFrount == true && isGround == false && hDirection != 0)
        {
            WallSliding = true;
        }
        else
        {
            WallSliding = false;
        }

        if (WallSliding)
        {


            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (Input.GetButtonDown("Jump") && WallSliding == true)
        {

            //rb.velocity = new Vector2(xWallForce * -hDirection, jumpForce);
            //state = State.jump;

            wallJumping = true;
            Invoke("SetWallJumpingToFalse", walljumpTime);

        }
        if (wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -hDirection, yWallForce);
            state = State.jump;
            // rb.velocity = new Vector2(xWallForce * , yWallForce);

        }

    }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }

}
