using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCoin : MonoBehaviour
{

    public GameObject DeathAnimation;
    public float launchForce;
    public float speed = 20f;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        rb.velocity = new Vector2(rb.velocity.x, launchForce);
        ChageDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Enemy")
        {
            
            Destroy(collision.gameObject);
            Instantiate(DeathAnimation, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else { }
        //Destroy(gameObject);

    }


    /*public void OnBecameInvisible()
    {
        //enabled = false;
        Destroy(gameObject);
    }*/

    public void ChageDirection()
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
    }


}
