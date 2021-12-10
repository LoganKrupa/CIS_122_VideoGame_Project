using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCoin : MonoBehaviour
{


    public float launchForce;
    public float speed = 20f;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        rb.velocity = new Vector2(rb.velocity.x, launchForce);
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
        }
        /*else if(collision.tag == "Ground")
        {
            Destroy(gameObject);
        }*/
        void OnBecameInvisible()
        {
            enabled = false;
            Destroy(gameObject);
        }
        //Destroy(gameObject);

    }

}
