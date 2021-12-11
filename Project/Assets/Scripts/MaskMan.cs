using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskMan : MonoBehaviour 
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLength = 2;
    [SerializeField] private float jumpHeight = 2;
    
    [SerializeField] private LayerMask Ground;

    private Collider2D coll;
    private Rigidbody2D rb;
    private Animator anim;

    //movement control varebles
    private bool isGround;
    public Transform Feet;
    public Transform Head;
    public bool isHead;
    public float checkRadius;
    public GameObject DeathAnimation;

    //Animation states
    private enum State { idle, run, jump, falling, hurt }
    private State state = State.idle;

    private bool facingLeft = true;


    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        // Showing that when the enemy hits a barrier it will turn around
        if (facingLeft)
        {
            if(transform.position.x > leftCap)
            {

                if(transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                //feet have to touch the ground to jump
                isGround = Physics2D.OverlapCircle(Feet.position, checkRadius, Ground);

                if (isGround == true)
                {
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    state = State.jump;
                }


            }

            else
            {
                facingLeft = false;
            }





        }
        else
        {
            if (transform.position.x < rightCap)
            {

                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                isGround = Physics2D.OverlapCircle(Feet.position, checkRadius, Ground);

                if (isGround == true)
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    state = State.jump;
                }


            }

            else
            {
                facingLeft = true;
            }
        }

        
        if(gameObject)

        //Animator controller
        //methods
        VelocityState();
        anim.SetInteger("State", (int)state);
        DestroyFrog();
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player" )
        {
            

            

            /*state = State.hurt;
            if(state == State.hurt)
            {
                //Destroy(gameObject);
                Instantiate(DeathAnimation, transform.position, Quaternion.identity);
            }*/
        }

        if(collision.gameObject.tag == "Projectile")
        {
            
            Destroy(gameObject);
        }

    }


    private void DestroyFrog()
    {
        if(gameObject == null)
        {
            //Instantiate(DeathAnimation, transform.position, Quaternion.identity);

        }

    }

    private void OnDestroy()
    {
        Instantiate(DeathAnimation, transform.position, Quaternion.identity);
    }


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
            if (coll.IsTouchingLayers(Ground))
            {
                state = State.idle;
            }

        }


        


    }
}
